import math

def method_kasatelnih(f, f_prime, a,b,eps =1e-6, max_iter = 100):

    x = (a + b) / 2
    iterations = 0

    print(f"{'a':>10} {'b':>10} {'x':>12} {'|b-a|':>12}")
    while (b - a) / 2 > eps and iterations < max_iter:
        iterations += 1

        # Проверка производной
        if abs(f_prime(x)) > 1e-12:
            x_new = x - f(x) / f_prime(x)
        else:
            x_new = (a + b) / 2

        # Корректировка x_new, если он вне интервала
        if x_new < a or x_new > b:
            x_new = (a + b) / 2

        # Выбор нового интервала
        if f(a) * f(x_new) < 0:
            b = x_new
        else:
            a = x_new

        x = x_new
        print(f"{a:10.6f} {b:10.6f} {x:12.6f} {(b - a):12.6f}")

    return x, iterations

def f(x):
    return math.sin(x)+math.log(x)

def f_prime(x):
   return math.cos(x)+1/x

root, iters = method_kasatelnih(f, f_prime, 1, 2, eps=1e-6)
print(f"Найденный корень: x = ~{root:.6f}, итераций: {iters}")

# Анализ и визуализация зависимости числа итераций от точности
import matplotlib.pyplot as plt

def analyze_iterations_vs_eps(f, f_prime, a, b, eps_values):
    iterations_list = []
    for eps in eps_values:
        _, iters = method_kasatelnih(f, f_prime, a, b, eps=eps)
        iterations_list.append(iters)
        print(f"eps={eps:.1e}, итераций={iters}")
    plt.figure()
    plt.plot(eps_values, iterations_list, marker='o')
    plt.xscale('log')
    plt.xlabel('Точность (eps)')
    plt.ylabel('Число итераций')
    plt.title('Зависимость числа итераций от точности')
    plt.grid(True)
    plt.show()
    # Пример анализа для f(x) = x^3 - 4 на [1, 2]
def f_example(x):
    return x**3 - 3
def f_example_prime(x):
    return 3 * x**2
eps_values = [1e-2, 1e-4, 1e-6, 1e-8, 1e-10, 1e-11, 1e-12, 1e-14]
analyze_iterations_vs_eps(f, f_prime, 1, 2, eps_values)
