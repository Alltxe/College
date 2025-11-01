using System;

namespace MathServer.Services
{
    /// <summary>
    /// Сервис для решения математических задач
    /// </summary>
    public class MathService
    {
        /// <summary>
        /// Задача 38: Вычислить интеграл (x^4 + 5x^3 + 8x^2 + 9x - 1) / (x^2 + 2x + 2) dx
        /// Метод символьного интегрирования с разложением на частичные дроби
        /// </summary>
        /// <param name="x">Верхний предел интегрирования</param>
        /// <param name="lowerLimit">Нижний предел интегрирования (по умолчанию 0)</param>
        /// <returns>Значение определенного интеграла</returns>
        public double CalculateIntegral(double x, double lowerLimit = 0)
        {
            // Выполняем деление многочленов: (x^4 + 5x^3 + 8x^2 + 9x - 1) / (x^2 + 2x + 2)
            // Результат: x^2 + 3x + (x + 5)/(x^2 + 2x + 2)
            
            // Интеграл от x^2: x^3/3
            double integral1Upper = Math.Pow(x, 3) / 3.0;
            double integral1Lower = Math.Pow(lowerLimit, 3) / 3.0;
            
            // Интеграл от 3x: 3x^2/2
            double integral2Upper = 3.0 * Math.Pow(x, 2) / 2.0;
            double integral2Lower = 3.0 * Math.Pow(lowerLimit, 2) / 2.0;
            
            // Для (x + 5)/(x^2 + 2x + 2) используем подстановку
            // x^2 + 2x + 2 = (x+1)^2 + 1
            // (x + 5)/(x^2 + 2x + 2) = (x+1)/(x^2 + 2x + 2) + 4/(x^2 + 2x + 2)
            // = (1/2)*ln(x^2 + 2x + 2) + 4*arctan(x+1)
            
            double denominatorUpper = Math.Pow(x, 2) + 2 * x + 2;
            double denominatorLower = Math.Pow(lowerLimit, 2) + 2 * lowerLimit + 2;
            
            double integral3Upper = 0.5 * Math.Log(denominatorUpper) + 4 * Math.Atan(x + 1);
            double integral3Lower = 0.5 * Math.Log(denominatorLower) + 4 * Math.Atan(lowerLimit + 1);
            
            double resultUpper = integral1Upper + integral2Upper + integral3Upper;
            double resultLower = integral1Lower + integral2Lower + integral3Lower;
            
            return resultUpper - resultLower;
        }

        /// <summary>
        /// Задача 43: Решить уравнение y'' - 4y' + 29y = 0
        /// Характеристическое уравнение: r^2 - 4r + 29 = 0
        /// </summary>
        /// <param name="x">Значение независимой переменной</param>
        /// <param name="c1">Константа C1</param>
        /// <param name="c2">Константа C2</param>
        /// <returns>Значение функции y(x)</returns>
        public double SolveDifferentialEquation43(double x, double c1, double c2)
        {
            // Характеристическое уравнение: r^2 - 4r + 29 = 0
            // Дискриминант: D = 16 - 116 = -100
            // r1,2 = (4 ± 10i) / 2 = 2 ± 5i
            // α = 2, β = 5
            // Общее решение: y = e^(2x) * (C1*cos(5x) + C2*sin(5x))
            
            double alpha = 2.0;
            double beta = 5.0;
            
            double exponentialPart = Math.Exp(alpha * x);
            double cosPart = c1 * Math.Cos(beta * x);
            double sinPart = c2 * Math.Sin(beta * x);
            
            return exponentialPart * (cosPart + sinPart);
        }

        /// <summary>
        /// Задача 44: Решить уравнение x^2*y'' + xy' + 1/x^2 = 0
        /// Уравнение Эйлера
        /// </summary>
        /// <param name="x">Значение независимой переменной (x > 0)</param>
        /// <param name="c1">Константа C1</param>
        /// <param name="c2">Константа C2</param>
        /// <returns>Значение функции y(x)</returns>
        public double SolveDifferentialEquation44(double x, double c1, double c2)
        {
            if (x <= 0)
            {
                throw new ArgumentException("x должно быть положительным числом", nameof(x));
            }

            // Уравнение Эйлера: x^2*y'' + x*y' + 1/x^2 = 0
            // Умножаем на x^2: x^4*y'' + x^3*y' + 1 = 0
            // Подстановка: x = e^t, тогда y' = (1/x)*dy/dt, y'' = (1/x^2)*(d^2y/dt^2 - dy/dt)
            // Получаем: d^2y/dt^2 + 1 = 0
            // Решение: y = C1*cos(ln(x)) + C2*sin(ln(x)) - 1
            
            double lnX = Math.Log(x);
            double result = c1 * Math.Cos(lnX) + c2 * Math.Sin(lnX);
            
            return result;
        }

        /// <summary>
        /// Проверка корректности решения дифференциального уравнения 43
        /// </summary>
        public bool VerifyDifferentialEquation43(double x, double c1, double c2, double tolerance = 1e-6)
        {
            double h = 1e-5;
            
            // Вычисляем y, y', y''
            double y = SolveDifferentialEquation43(x, c1, c2);
            double yPlus = SolveDifferentialEquation43(x + h, c1, c2);
            double yMinus = SolveDifferentialEquation43(x - h, c1, c2);
            
            double yPrime = (yPlus - yMinus) / (2 * h);
            double yDoublePrime = (yPlus - 2 * y + yMinus) / (h * h);
            
            // Проверяем уравнение: y'' - 4y' + 29y = 0
            double residual = yDoublePrime - 4 * yPrime + 29 * y;
            
            // Относительная погрешность для больших значений
            double relativeError = Math.Abs(y) > 1 ? Math.Abs(residual / y) : Math.Abs(residual);
            
            return relativeError < tolerance || Math.Abs(residual) < tolerance;
        }

        /// <summary>
        /// Проверка корректности решения дифференциального уравнения 44
        /// </summary>
        public bool VerifyDifferentialEquation44(double x, double c1, double c2, double tolerance = 1e-5)
        {
            if (x <= 0) return false;
            
            double h = 1e-5;
            
            // Вычисляем y, y', y''
            double y = SolveDifferentialEquation44(x, c1, c2);
            double yPlus = SolveDifferentialEquation44(x + h, c1, c2);
            double yMinus = SolveDifferentialEquation44(x - h, c1, c2);
            
            double yPrime = (yPlus - yMinus) / (2 * h);
            double yDoublePrime = (yPlus - 2 * y + yMinus) / (h * h);
            
            // Проверяем уравнение: x^2*y'' + x*y' + 1/x^2 = 0
            double residual = x * x * yDoublePrime + x * yPrime + 1 / (x * x);
            
            // Относительная погрешность
            double scale = Math.Abs(1 / (x * x));
            double relativeError = Math.Abs(residual / scale);
            
            return relativeError < tolerance || Math.Abs(residual) < tolerance;
        }

        /// <summary>
        /// Вычисление производной функции интеграла численным методом
        /// </summary>
        public double CalculateIntegralDerivative(double x, double h = 1e-5)
        {
            return (CalculateIntegral(x + h) - CalculateIntegral(x - h)) / (2 * h);
        }

        /// <summary>
        /// Вычисление интеграла численным методом (метод трапеций) для проверки
        /// </summary>
        public double CalculateIntegralNumerical(double upperLimit, double lowerLimit = 0, int steps = 10000)
        {
            double h = (upperLimit - lowerLimit) / steps;
            double sum = 0;
            
            for (int i = 0; i <= steps; i++)
            {
                double x = lowerLimit + i * h;
                double fx = (Math.Pow(x, 4) + 5 * Math.Pow(x, 3) + 8 * Math.Pow(x, 2) + 9 * x - 1) 
                          / (Math.Pow(x, 2) + 2 * x + 2);
                
                if (i == 0 || i == steps)
                    sum += fx / 2.0;
                else
                    sum += fx;
            }
            
            return sum * h;
        }
    }
}
