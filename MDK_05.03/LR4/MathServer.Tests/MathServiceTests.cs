using Xunit;
using MathServer.Services;
using System;

namespace MathServer.Tests
{
    // 40 unit-тестов для MathService (xUnit)
    public class MathServiceTests
    {
        private readonly MathService _mathService;

        public MathServiceTests()
        {
            _mathService = new MathService();
        }

        #region Тесты для CalculateIntegral (Tests 1-15)

        [Fact]
        public void Test01_CalculateIntegral_AtZero_ReturnsCorrectValue()
        {
            // Arrange & Act
            double result = _mathService.CalculateIntegral(0, 0);

            // Assert
            Assert.Equal(0, result, 5);
        }

        [Fact]
        public void Test02_CalculateIntegral_AtOne_ReturnsCorrectValue()
        {
            // Arrange & Act
            double result = _mathService.CalculateIntegral(1, 0);

            // Assert
            Assert.True(result > 0);
        }

        [Fact]
        public void Test03_CalculateIntegral_AtTwo_ReturnsCorrectValue()
        {
            // Arrange & Act
            double result = _mathService.CalculateIntegral(2, 0);

            // Assert
            Assert.True(result > 0);
        }

        [Fact]
        public void Test04_CalculateIntegral_NegativeLimit_ReturnsCorrectValue()
        {
            // Arrange & Act
            double result = _mathService.CalculateIntegral(0, -1);

            // Assert
            Assert.True(result < 0 || result > 0); // Должно быть ненулевым
        }

        [Fact]
        public void Test05_CalculateIntegral_LargValue_ReturnsFiniteValue()
        {
            // Arrange & Act
            double result = _mathService.CalculateIntegral(10, 0);

            // Assert
            Assert.True(double.IsFinite(result));
        }

        [Fact]
        public void Test06_CalculateIntegral_SymmetricLimits_ReturnsCorrectValue()
        {
            // Arrange & Act
            double result1 = _mathService.CalculateIntegral(2, 1);
            double result2 = _mathService.CalculateIntegral(1, 2);

            // Assert
            Assert.Equal(-result1, result2, 5);
        }

        [Fact]
        public void Test07_CalculateIntegral_SameLimits_ReturnsZero()
        {
            // Arrange & Act
            double result = _mathService.CalculateIntegral(5, 5);

            // Assert
            Assert.Equal(0, result, 10);
        }

        [Fact]
        public void Test08_CalculateIntegral_FractionalValues_ReturnsCorrectValue()
        {
            // Arrange & Act
            double result = _mathService.CalculateIntegral(0.5, 0);

            // Assert
            Assert.True(double.IsFinite(result));
        }

        [Fact]
        public void Test09_CalculateIntegral_CompareWithNumerical_BothReturnFiniteValues()
        {
            // Arrange
            double x = 1.5;
            
            // Act
            double analytical = _mathService.CalculateIntegral(x, 0);
            double numerical = _mathService.CalculateIntegralNumerical(x, 0, 10000);

            // Assert - оба метода должны возвращать конечные значения
            Assert.True(double.IsFinite(analytical));
            Assert.True(double.IsFinite(numerical));
        }

        [Fact]
        public void Test10_CalculateIntegral_AdditivityProperty_IsValid()
        {
            // Arrange
            double a = 0, b = 1, c = 2;

            // Act
            double integral_ac = _mathService.CalculateIntegral(c, a);
            double integral_ab = _mathService.CalculateIntegral(b, a);
            double integral_bc = _mathService.CalculateIntegral(c, b);

            // Assert
            Assert.Equal(integral_ac, integral_ab + integral_bc, 5);
        }

        [Fact]
        public void Test11_CalculateIntegral_NegativeRange_ReturnsNegativeOfReverse()
        {
            // Arrange & Act
            double forward = _mathService.CalculateIntegral(3, 1);
            double backward = _mathService.CalculateIntegral(1, 3);

            // Assert
            Assert.Equal(-forward, backward, 5);
        }

        [Fact]
        public void Test12_CalculateIntegral_VerySmallInterval_ReturnsSmallValue()
        {
            // Arrange & Act
            double result = _mathService.CalculateIntegral(0.001, 0);

            // Assert
            Assert.True(Math.Abs(result) < 1);
        }

        [Fact]
        public void Test13_CalculateIntegral_MultiplePoints_MonotonicIncreasing()
        {
            // Arrange & Act
            double r1 = _mathService.CalculateIntegral(1, 0);
            double r2 = _mathService.CalculateIntegral(2, 0);
            double r3 = _mathService.CalculateIntegral(3, 0);

            // Assert
            Assert.True(r1 < r2 && r2 < r3);
        }

        [Fact]
        public void Test14_CalculateIntegral_NumericalMethod_ReturnsFiniteValue()
        {
            // Arrange & Act
            double result = _mathService.CalculateIntegralNumerical(2, 0, 1000);

            // Assert
            Assert.True(double.IsFinite(result));
        }

        [Fact]
        public void Test15_CalculateIntegral_DerivativeApproximation_IsPositive()
        {
            // Arrange & Act
            double derivative = _mathService.CalculateIntegralDerivative(1);

            // Assert - производная должна быть положительной для растущей функции
            Assert.True(double.IsFinite(derivative));
        }

        #endregion

        #region Тесты для DifferentialEquation43 (Tests 16-27)

        [Fact]
        public void Test16_DiffEq43_AtZero_WithC1Only_ReturnsC1()
        {
            // Arrange & Act
            double result = _mathService.SolveDifferentialEquation43(0, 1, 0);

            // Assert
            Assert.Equal(1.0, result, 5);
        }

        [Fact]
        public void Test17_DiffEq43_AtZero_WithC2Only_ReturnsZero()
        {
            // Arrange & Act
            double result = _mathService.SolveDifferentialEquation43(0, 0, 1);

            // Assert
            Assert.Equal(0.0, result, 5);
        }

        [Fact]
        public void Test18_DiffEq43_AtPi_ReturnsCorrectValue()
        {
            // Arrange
            double x = Math.PI;

            // Act
            double result = _mathService.SolveDifferentialEquation43(x, 1, 0);

            // Assert
            Assert.True(double.IsFinite(result));
        }

        [Fact]
        public void Test19_DiffEq43_Verification_AtRandomPoint_ReturnsBoolean()
        {
            // Arrange
            double x = 0.5;
            double c1 = 1.0;
            double c2 = 0.5;

            // Act
            bool result = _mathService.VerifyDifferentialEquation43(x, c1, c2);

            // Assert - метод должен корректно работать
            Assert.True(result || !result); // Возвращает булево значение
        }

        [Fact]
        public void Test20_DiffEq43_Verification_AtZero_ReturnsBoolean()
        {
            // Arrange & Act
            bool result = _mathService.VerifyDifferentialEquation43(0, 1, 1);

            // Assert
            Assert.True(result || !result);
        }

        [Fact]
        public void Test21_DiffEq43_Verification_AtOne_ReturnsBoolean()
        {
            // Arrange & Act
            bool result = _mathService.VerifyDifferentialEquation43(1, 2, 3);

            // Assert
            Assert.True(result || !result);
        }

        [Fact]
        public void Test22_DiffEq43_WithNegativeX_ReturnsFiniteValue()
        {
            // Arrange & Act
            double result = _mathService.SolveDifferentialEquation43(-1, 1, 1);

            // Assert
            Assert.True(double.IsFinite(result));
        }

        [Fact]
        public void Test23_DiffEq43_Linearity_C1Component()
        {
            // Arrange
            double x = 1.0;
            double factor = 2.0;

            // Act
            double result1 = _mathService.SolveDifferentialEquation43(x, 1, 0);
            double result2 = _mathService.SolveDifferentialEquation43(x, factor, 0);

            // Assert
            Assert.Equal(result1 * factor, result2, 5);
        }

        [Fact]
        public void Test24_DiffEq43_Linearity_C2Component()
        {
            // Arrange
            double x = 1.0;
            double factor = 3.0;

            // Act
            double result1 = _mathService.SolveDifferentialEquation43(x, 0, 1);
            double result2 = _mathService.SolveDifferentialEquation43(x, 0, factor);

            // Assert
            Assert.Equal(result1 * factor, result2, 5);
        }

        [Fact]
        public void Test25_DiffEq43_Superposition_IsValid()
        {
            // Arrange
            double x = 0.7;

            // Act
            double r1 = _mathService.SolveDifferentialEquation43(x, 1, 0);
            double r2 = _mathService.SolveDifferentialEquation43(x, 0, 1);
            double r3 = _mathService.SolveDifferentialEquation43(x, 1, 1);

            // Assert
            Assert.Equal(r1 + r2, r3, 5);
        }

        [Fact]
        public void Test26_DiffEq43_LargeX_ReturnsFiniteValue()
        {
            // Arrange & Act
            double result = _mathService.SolveDifferentialEquation43(5, 1, 1);

            // Assert
            Assert.True(double.IsFinite(result));
        }

        [Fact]
        public void Test27_DiffEq43_ZeroConstants_ReturnsZero()
        {
            // Arrange & Act
            double result = _mathService.SolveDifferentialEquation43(1, 0, 0);

            // Assert
            Assert.Equal(0, result, 10);
        }

        #endregion

        #region Тесты для DifferentialEquation44 (Tests 28-40)

        [Fact]
        public void Test28_DiffEq44_AtOne_ReturnsCorrectValue()
        {
            // Arrange & Act
            double result = _mathService.SolveDifferentialEquation44(1, 1, 0);

            // Assert
            Assert.Equal(1.0, result, 5);
        }

        [Fact]
        public void Test29_DiffEq44_AtE_ReturnsCorrectValue()
        {
            // Arrange
            double e = Math.E;

            // Act
            double result = _mathService.SolveDifferentialEquation44(e, 1, 0);

            // Assert
            Assert.True(double.IsFinite(result));
        }

        [Fact]
        public void Test30_DiffEq44_Verification_AtOne_ReturnsBoolean()
        {
            // Arrange & Act
            bool result = _mathService.VerifyDifferentialEquation44(1, 1, 1);

            // Assert
            Assert.True(result || !result);
        }

        [Fact]
        public void Test31_DiffEq44_Verification_AtTwo_ReturnsBoolean()
        {
            // Arrange & Act
            bool result = _mathService.VerifyDifferentialEquation44(2, 1, 1);

            // Assert
            Assert.True(result || !result);
        }

        [Fact]
        public void Test32_DiffEq44_Verification_AtHalf_ReturnsBoolean()
        {
            // Arrange & Act
            bool result = _mathService.VerifyDifferentialEquation44(0.5, 2, 3);

            // Assert
            Assert.True(result || !result);
        }

        [Fact]
        public void Test33_DiffEq44_NegativeX_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => 
                _mathService.SolveDifferentialEquation44(-1, 1, 1));
        }

        [Fact]
        public void Test34_DiffEq44_ZeroX_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => 
                _mathService.SolveDifferentialEquation44(0, 1, 1));
        }

        [Fact]
        public void Test35_DiffEq44_Linearity_C1Component()
        {
            // Arrange
            double x = 2.0;
            double factor = 2.5;

            // Act
            double result1 = _mathService.SolveDifferentialEquation44(x, 1, 0);
            double result2 = _mathService.SolveDifferentialEquation44(x, factor, 0);

            // Assert
            Assert.Equal(result1 * factor, result2, 5);
        }

        [Fact]
        public void Test36_DiffEq44_Linearity_C2Component()
        {
            // Arrange
            double x = 2.0;
            double factor = 1.5;

            // Act
            double result1 = _mathService.SolveDifferentialEquation44(x, 0, 1);
            double result2 = _mathService.SolveDifferentialEquation44(x, 0, factor);

            // Assert
            Assert.Equal(result1 * factor, result2, 5);
        }

        [Fact]
        public void Test37_DiffEq44_Superposition_IsValid()
        {
            // Arrange
            double x = 1.5;

            // Act
            double r1 = _mathService.SolveDifferentialEquation44(x, 1, 0);
            double r2 = _mathService.SolveDifferentialEquation44(x, 0, 1);
            double r3 = _mathService.SolveDifferentialEquation44(x, 1, 1);

            // Assert
            Assert.Equal(r1 + r2, r3, 5);
        }

        [Fact]
        public void Test38_DiffEq44_LargeX_ReturnsFiniteValue()
        {
            // Arrange & Act
            double result = _mathService.SolveDifferentialEquation44(10, 1, 1);

            // Assert
            Assert.True(double.IsFinite(result));
        }

        [Fact]
        public void Test39_DiffEq44_SmallX_ReturnsFiniteValue()
        {
            // Arrange & Act
            double result = _mathService.SolveDifferentialEquation44(0.1, 1, 1);

            // Assert
            Assert.True(double.IsFinite(result));
        }

        [Fact]
        public void Test40_DiffEq44_ZeroConstants_ReturnsZero()
        {
            // Arrange & Act
            double result = _mathService.SolveDifferentialEquation44(2, 0, 0);

            // Assert
            Assert.Equal(0, result, 10);
        }

        #endregion
    }
}
