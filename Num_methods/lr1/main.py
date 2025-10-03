
from math import sin, log
import matplotlib.pyplot as plt

def f(x):
    return sin(x) + log(x)

def halfDivision(a, b, E=1e-4):
    x = 0
    delta = abs(a-b)
    iterations = 0

    if f(a) * f(b) >= 0:
        raise ValueError(f"Функция должна иметь разные знаки на концах отрезка [{a}, {b}]. "
                        f"f({a}) = {f(a)}, f({b}) = {f(b)}")

    while (delta > E):
        delta = abs(a-b)
        x = (a+b)/2
        func_val = f(x)
        # print('iter ', iterations, ': ', a, ' ', b, ' ', func_val)
        iterations += 1
        if(func_val < 0):
            a = x
        else:
            b = x

    # print(f"iterations: {iterations}")
    return x, iterations

def analyze_iterations(a, b):
    E_values = [1e-1, 1e-2, 1e-3, 1e-4, 1e-5, 1e-6, 1e-7, 1e-8, 1e-9, 1e-10]
    iterations_list = []
    for E in E_values:
        _, iterations = halfDivision_with_E(a, b, E)
        iterations_list.append(iterations)
    plt.figure(figsize=(8,5))
    plt.plot(E_values, iterations_list, marker='o')
    plt.xscale('log')
    plt.xlabel('E (точность)')
    plt.ylabel('Количество итераций')
    plt.title('Зависимость количества итераций от точности E')
    plt.grid(True)
    plt.show()

def halfDivision_with_E(a, b, E):
    x = 0
    delta = abs(a-b)
    iterations = 0
    if f(a) * f(b) >= 0:
        raise ValueError(f"Функция должна иметь разные знаки на концах отрезка [{a}, {b}]. "
                        f"f({a}) = {f(a)}, f({b}) = {f(b)}")
    while (delta > E):
        delta = abs(a-b)
        x = (a+b)/2
        func_val = f(x)
        iterations += 1
        if(func_val < 0):
            a = x
        else:
            b = x
    return x, iterations

if __name__ == '__main__':
    root, iterations = halfDivision(0.1, 2)
    print(f"Корень: {root}, итераций: {iterations}")
    analyze_iterations(0.1, 2)