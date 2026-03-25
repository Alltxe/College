import sys
import os

sys.path.insert(0, os.path.dirname(__file__))

import tkinter as tk
from forms.login_form import LoginForm

if __name__ == "__main__":
    root = tk.Tk()
    LoginForm(root)
    root.mainloop()
