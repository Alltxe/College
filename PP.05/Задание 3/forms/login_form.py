import tkinter as tk
from tkinter import messagebox

from components.captcha_widget import CaptchaWidget
from models.user import User, hash_password

APP_TITLE = "ИС ООО \"Полесье\""


class LoginForm:
    def __init__(self, root: tk.Tk):
        self._root = root
        root.title(f"{APP_TITLE} — Авторизация")
        root.resizable(True, True)
        root.minsize(340, 480)

        frame = tk.Frame(root, padx=20, pady=20)
        frame.pack(fill="both", expand=True)
        frame.columnconfigure(1, weight=1)

        tk.Label(frame, text=APP_TITLE, font=("Segoe UI", 13, "bold")).grid(
            row=0, column=0, columnspan=2, pady=(0, 16)
        )

        tk.Label(frame, text="Логин:").grid(row=1, column=0, sticky="w", pady=4)
        self._username_var = tk.StringVar()
        tk.Entry(frame, textvariable=self._username_var).grid(
            row=1, column=1, sticky="ew", pady=4
        )

        tk.Label(frame, text="Пароль:").grid(row=2, column=0, sticky="w", pady=4)
        self._password_var = tk.StringVar()
        tk.Entry(frame, textvariable=self._password_var, show="*").grid(
            row=2, column=1, sticky="ew", pady=4
        )

        tk.Label(
            frame,
            text="Внимание: неверная капча также засчитывается как неудачная попытка.",
            font=("Segoe UI", 8),
            fg="gray",
            wraplength=280,
            justify="left",
        ).grid(row=3, column=0, columnspan=2, sticky="w", pady=(4, 0))

        self._captcha = CaptchaWidget(frame)
        self._captcha.grid(row=4, column=0, columnspan=2, pady=10)

        btn_frame = tk.Frame(frame)
        btn_frame.grid(row=5, column=0, columnspan=2, pady=(4, 0))

        tk.Button(btn_frame, text="Обновить капчу", command=self._captcha.reset).pack(
            side="left", padx=4
        )
        tk.Button(btn_frame, text="Проверить капчу", command=self._check_captcha).pack(
            side="left", padx=4
        )
        tk.Button(btn_frame, text="Войти", width=10, command=self._on_login).pack(
            side="left", padx=4
        )

        root.bind("<Return>", lambda _: self._on_login())

    def _check_captcha(self):
        if self._captcha.is_solved():
            messagebox.showinfo("Капча", "Капча пройдена успешно!")
        else:
            messagebox.showwarning("Капча", "Фрагменты расставлены неверно. Попробуйте ещё раз.")

    def _on_login(self):
        username = self._username_var.get().strip()
        password = self._password_var.get().strip()

        if not username or not password:
            messagebox.showwarning("Предупреждение", "Поля «Логин» и «Пароль» обязательны для заполнения.")
            return

        try:
            row = User.get_by_username(username)
        except Exception as exc:
            messagebox.showerror("Ошибка БД", f"Не удалось подключиться к базе данных:\n{exc}")
            return

        if row is None:
            messagebox.showerror(
                "Ошибка входа",
                "Вы ввели неверный логин или пароль.\nПожалуйста проверьте ещё раз введённые данные.",
            )
            return

        user_id, _, db_password, role, is_blocked, _ = row

        if is_blocked:
            messagebox.showerror(
                "Доступ запрещён",
                "Вы заблокированы.\nОбратитесь к администратору.",
            )
            return

        if not self._captcha.is_solved():
            self._handle_failure(user_id, "Капча собрана неверно. Повторите попытку.")
            return

        if hash_password(password) != db_password:
            self._handle_failure(
                user_id,
                "Вы ввели неверный логин или пароль.\nПожалуйста проверьте ещё раз введённые данные.",
            )
            return

        User.reset_failures(user_id)
        messagebox.showinfo("Успех", "Вы успешно авторизовались.")
        self._open_main(role)

    def _handle_failure(self, user_id: int, message: str):
        User.increment_failures(user_id)
        updated = User.get_by_username(self._username_var.get().strip())
        self._captcha.reset()
        if updated and updated[4]:  # is_blocked
            messagebox.showerror(
                "Доступ запрещён",
                "Вы заблокированы.\nОбратитесь к администратору.",
            )
        else:
            messagebox.showerror("Ошибка входа", message)

    def _open_main(self, role: str):
        from forms.admin_form import AdminForm

        self._root.withdraw()
        top = tk.Toplevel()

        def on_logout():
            top.destroy()
            self._username_var.set("")
            self._password_var.set("")
            self._captcha.reset()
            self._root.deiconify()

        top.protocol("WM_DELETE_WINDOW", on_logout)

        if role == "Администратор":
            AdminForm(top, on_logout=on_logout)
        else:
            top.title(f"{APP_TITLE} — Рабочий стол")
            top.minsize(320, 180)
            tk.Label(top, text=f"Добро пожаловать, {self._username_var.get()}!", padx=20, pady=30).pack()
            tk.Button(top, text="Выход из учётной записи", command=on_logout).pack(pady=(0, 20))
