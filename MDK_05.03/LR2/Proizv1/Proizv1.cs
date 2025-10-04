using System;

namespace Proizv1
{
    public static class Derivatives
    {
        // a) y = 1/4 x^2 (2 ln x - 3)
        public static double SecondDerivative_VariantA(double x)
        {
            if (x <= 0) throw new ArgumentOutOfRangeException(nameof(x), "x must be > 0 for ln(x)");
            // y' = x ln(x) - x
            // y'' = ln(x)
            return Math.Log(x);
        }

        // в) y = -1/9 x * sin 3x - 2/27 cos 3x
        public static double SecondDerivative_VariantV(double x)
        {
            //y' = -sin(3x)/9 - x*cos(3x)/3
            //y'' = x*sin(3x)
            return x * Math.Sin(3 * x);
        }
    }
}
