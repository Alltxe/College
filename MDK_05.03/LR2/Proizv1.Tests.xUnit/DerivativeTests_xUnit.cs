using System;
using Xunit;
using Proizv1;

namespace Proizv1.Tests.xUnit
{
    public class DerivativeTests
    {
        [Theory]
        [InlineData(1.0)]
        [InlineData(2.7182818284590451)]
        [InlineData(2.0)]
        [InlineData(0.5)]
        [InlineData(10.0)]
        [InlineData(0.001)]
        [InlineData(12345.6)]
        [InlineData(7.38905609893065)]
        [InlineData(3.1415)]
        [InlineData(0.01)]
        [InlineData(0.1)]
        [InlineData(0.000001)]
        [InlineData(1000.0)]
    [InlineData(99999.0)]
        public void VariantA_TestCases(double x)
        {
            Assert.Equal(Math.Log(x), Derivatives.SecondDerivative_VariantA(x), 12);
        }

        [Theory]
        [InlineData(0.0)]
        [InlineData(3.1415926535897931)]
        [InlineData(1.0471975511965976)]
        [InlineData(-0.7853981633974483)]
        [InlineData(0.1)]
        [InlineData(-0.5)]
        [InlineData(1.0)]
        [InlineData(2.0)]
        [InlineData(3.1415)]
        [InlineData(10.0)]
        [InlineData(-10.0)]
        [InlineData(100.0)]
        [InlineData(-100.0)]
        [InlineData(0.001)]
        [InlineData(1000.0)]
        public void VariantV_TestCases(double x)
        {
            var expected = x * Math.Sin(3 * x);
            Assert.Equal(expected, Derivatives.SecondDerivative_VariantV(x), 12);
        }
    }
}
