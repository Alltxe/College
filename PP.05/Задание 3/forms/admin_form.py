import tkinter as tk
from tkinter import ttk, messagebox

from models.user import User, hash_password

APP_TITLE = "ИС ООО \"Полесье\""


class AdminForm:
    def __init__(self, root: tk.Tk | tk.Toplevel, on_logout=None):
        self._root = root
        root.title(f"{APP_TITLE} — Администратор")
        root.resizable(True, True)
        root.minsize(620, 360)

        frame = tk.Frame(root, padx=10, pady=10)
        frame.pack(fill="both", expand=True)
        frame.rowconfigure(0, weight=1)
        frame.columnconfigure(0, weight=1)

        columns = ("id", "username", "role", "blocked")
        self._tree = ttk.Treeview(frame, columns=columns, show="headings", selectmode="browse")
        for col, heading, width in [
            ("id", "ID", 40),
            ("username", "Логин", 160),
            ("role", "Роль", 140),
            ("blocked", "Заблокирован", 110),
        ]:
            self._tree.heading(col, text=heading)
            self._tree.column(col, width=width, minwidth=40)
        scrollbar = ttk.Scrollbar(frame, orient="vertical", command=self._tree.yview)
        self._tree.configure(yscrollcommand=scrollbar.set)
        self._tree.grid(row=0, column=0, sticky="nsew")
        scrollbar.grid(row=0, column=1, sticky="ns")

        btn_frame = tk.Frame(frame)
        btn_frame.grid(row=1, column=0, columnspan=2, pady=(8, 0), sticky="ew")

        tk.Button(btn_frame, text="Добавить", width=12, command=self._on_add).pack(side="left", padx=4)
        tk.Button(btn_frame, text="Редактировать", width=14, command=self._on_edit).pack(side="left", padx=4)
        tk.Button(btn_frame, text="Снять блокировку", width=16, command=self._on_unblock).pack(side="left", padx=4)
        tk.Button(btn_frame, text="Обновить", width=10, command=self._load_users).pack(side="left", padx=4)

        if on_logout:
            tk.Button(btn_frame, text="Выход из учётной записи", command=on_logout).pack(side="right", padx=4)

        self._load_users()

    def _load_users(self):
        for row in self._tree.get_children():
            self._tree.delete(row)
        try:
            for user_id, username, role, is_blocked, _ in User.get_all():
                self._tree.insert("", "end", values=(user_id, username, role or "—", "Да" if is_blocked else "Нет"))
        except Exception as exc:
            messagebox.showerror("Ошибка БД", str(exc))

    def _selected_id(self) -> int | None:
        sel = self._tree.selection()
        if not sel:
            messagebox.showwarning("Выбор", "Выберите пользователя в списке.")
            return None
        return int(self._tree.item(sel[0])["values"][0])

    def _on_add(self):
        UserDialog(self._root, on_save=self._load_users)

    def _on_edit(self):
        user_id = self._selected_id()
        if user_id is None:
            return
        sel = self._tree.selection()[0]
        values = self._tree.item(sel)["values"]
        username, role, blocked = values[1], values[2], values[3] == "Да"
        UserDialog(self._root, on_save=self._load_users, user_id=user_id, username=username, role=role, is_blocked=blocked)

    def _on_unblock(self):
        user_id = self._selected_id()
        if user_id is None:
            return
        try:
            User.unblock(user_id)
            self._load_users()
            messagebox.showinfo("Готово", "Блокировка снята.")
        except Exception as exc:
            messagebox.showerror("Ошибка БД", str(exc))


class UserDialog:
    """Диалог добавления/редактирования пользователя."""

    def __init__(self, parent, on_save, user_id=None, username="", role="", is_blocked=False):
        self._user_id = user_id
        self._on_save = on_save
        self._original_username = username

        top = tk.Toplevel(parent)
        top.title("Новый пользователь" if user_id is None else "Редактирование пользователя")
        top.resizable(False, False)
        top.grab_set()

        frame = tk.Frame(top, padx=16, pady=16)
        frame.pack()
        frame.columnconfigure(1, weight=1)

        tk.Label(frame, text="Логин:").grid(row=0, column=0, sticky="w", pady=4)
        self._username_var = tk.StringVar(value=username)
        tk.Entry(frame, textvariable=self._username_var, width=28).grid(row=0, column=1, pady=4)

        tk.Label(frame, text="Пароль:").grid(row=1, column=0, sticky="w", pady=4)
        self._password_var = tk.StringVar()
        hint = "" if user_id is None else " (оставьте пустым, чтобы не менять)"
        tk.Entry(frame, textvariable=self._password_var, show="*", width=28).grid(row=1, column=1, pady=4)
        if hint:
            tk.Label(frame, text=hint, font=("Segoe UI", 8), fg="gray").grid(
                row=2, column=1, sticky="w", pady=(0, 4)
            )

        label_row = 3 if hint else 2
        tk.Label(frame, text="Роль:").grid(row=label_row, column=0, sticky="w", pady=4)
        try:
            roles = User.get_roles()
        except Exception:
            roles = ["Администратор", "Пользователь"]
        self._role_var = tk.StringVar(value=role if role in roles else (roles[0] if roles else ""))
        ttk.Combobox(frame, textvariable=self._role_var, values=roles, state="readonly", width=26).grid(
            row=label_row, column=1, pady=4
        )

        self._blocked_var = tk.BooleanVar(value=is_blocked)
        tk.Checkbutton(frame, text="Заблокирован", variable=self._blocked_var).grid(
            row=label_row + 1, column=0, columnspan=2, sticky="w", pady=4
        )

        btn_row = tk.Frame(frame)
        btn_row.grid(row=label_row + 2, column=0, columnspan=2, pady=(10, 0))
        tk.Button(btn_row, text="Сохранить", width=12, command=lambda: self._save(top)).pack(side="left", padx=4)
        tk.Button(btn_row, text="Отмена", width=10, command=top.destroy).pack(side="left", padx=4)

    def _save(self, top: tk.Toplevel):
        username = self._username_var.get().strip()
        password = self._password_var.get().strip()
        role = self._role_var.get()
        is_blocked = self._blocked_var.get()

        if not username:
            messagebox.showwarning("Ошибка", "Поле «Логин» обязательно.", parent=top)
            return
        if self._user_id is None and not password:
            messagebox.showwarning("Ошибка", "Поле «Пароль» обязательно.", parent=top)
            return

        try:
            if self._user_id is None:
                if User.exists(username):
                    messagebox.showwarning("Ошибка", f"Пользователь «{username}» уже существует.", parent=top)
                    return
                User.create(username, password, role, is_blocked)
            else:
                if username != self._original_username and User.exists(username):
                    messagebox.showwarning("Ошибка", f"Пользователь «{username}» уже существует.", parent=top)
                    return
                User.update(self._user_id, username, role, is_blocked, new_password=password or None)
        except Exception as exc:
            messagebox.showerror("Ошибка БД", str(exc), parent=top)
            return

        top.destroy()
        self._on_save()
