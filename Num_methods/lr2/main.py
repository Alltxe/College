import math
import matplotlib.pyplot as plt

def f(x):
    return x**2 - 2

def chord_method(func, a, b, eps=1e-5, max_iter=100, verbose=True):
   if func(a) * func(b) > 0:
       if verbose:
           print(f"Возможная ошибка: на интервале [{a}, {b}] корень может отсутствовать или их несколько.")
           pass

   iteration = 0
   x_new = b
   while iteration < max_iter:
       fa = func(a)
       fb = func(b)
       x_new = b - fb * (b - a) / (fb - fa)
       iteration += 1

       if verbose:
           print(f"iter {iteration}: a={a:.6f}, b={b:.6f}, x_new={x_new:.6f}, |b-a|={abs(b-a):.6f}")

       if abs(func(x_new)) < eps or abs(b-a) < eps:
           return x_new, iteration

       if fa * func(x_new) < 0:
           b = x_new
       else:
           a = x_new

   return x_new, iteration


# Анализ количества итераций в зависимости от eps
eps_values = [1e-1, 1e-2, 1e-3, 1e-4, 1e-5, 1e-6, 1e-7]
iterations = []
roots = []
for eps in eps_values:
    root, iters = chord_method(f, 0.1, 2, eps=eps, verbose=False)
    iterations.append(iters)
    roots.append(root)
    print(f"eps={eps:.0e}: root={root:.6f}, iterations={iters}")

# Визуализация зависимости количества итераций от eps
plt.figure(figsize=(8, 5))
plt.plot(eps_values, iterations, marker='o')
plt.xscale('log')
plt.xlabel('eps')
plt.ylabel('Количество итераций')
plt.title('Зависимость числа итераций от точности eps')
plt.grid(True)
plt.show()

