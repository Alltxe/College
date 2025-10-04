using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Proizv1;

namespace Proizv1.Tests.MSTest
{
    [TestClass]
    public class DerivativeTests
    {
        // 15 tests for Variant A (SecondDerivative_VariantA)

        [TestMethod]
        public void VariantA_At1_Returns0()
        {
            Assert.AreEqual(0, Derivatives.SecondDerivative_VariantA(1), 1e-12);
        }

        [TestMethod]
        public void VariantA_AtE_Returns1()
        {
            Assert.AreEqual(1, Derivatives.SecondDerivative_VariantA(Math.E), 1e-12);
        }

        [TestMethod]
        public void VariantA_At2()
        {
            Assert.AreEqual(Math.Log(2), Derivatives.SecondDerivative_VariantA(2), 1e-12);
        }

        [TestMethod]
        public void VariantA_SmallPositive()
        {
            double x = 0.5;
            Assert.AreEqual(Math.Log(x), Derivatives.SecondDerivative_VariantA(x), 1e-12);
        }

        [TestMethod]
        public void VariantA_Large()
        {
            double x = 1e6;
            Assert.AreEqual(Math.Log(x), Derivatives.SecondDerivative_VariantA(x), 1e-12);
        }

        [TestMethod]
        public void VariantA_VerySmall()
        {
            double x = 1e-6;
            Assert.AreEqual(Math.Log(x), Derivatives.SecondDerivative_VariantA(x), 1e-12);
        }

        [TestMethod]
        public void VariantA_Elevated()
        {
            double x = Math.Exp(2);
            Assert.AreEqual(Math.Log(x), Derivatives.SecondDerivative_VariantA(x), 1e-12);
        }

        [TestMethod]
        public void VariantA_Decimal()
        {
            double x = 3.1415;
            Assert.AreEqual(Math.Log(x), Derivatives.SecondDerivative_VariantA(x), 1e-12);
        }

        [TestMethod]
        public void VariantA_RandomSamples1()
        {
            var rnd = new Random(1);
            for (int i = 0; i < 5; i++)
            {
                double x = 0.1 + rnd.NextDouble() * 10;
                Assert.AreEqual(Math.Log(x), Derivatives.SecondDerivative_VariantA(x), 1e-12);
            }
        }

        [TestMethod]
        public void VariantA_RandomSamples2()
        {
            var rnd = new Random(2);
            for (int i = 0; i < 5; i++)
            {
                double x = 0.01 + rnd.NextDouble() * 100;
                Assert.AreEqual(Math.Log(x), Derivatives.SecondDerivative_VariantA(x), 1e-12);
            }
        }

        [TestMethod]
        public void VariantA_LogOneThousand()
        {
            double x = 1000;
            Assert.AreEqual(Math.Log(x), Derivatives.SecondDerivative_VariantA(x), 1e-12);
        }

        [TestMethod]
        public void VariantA_LogEpsilon()
        {
            double x = 1e-9;
            Assert.AreEqual(Math.Log(x), Derivatives.SecondDerivative_VariantA(x), 1e-12);
        }

        [TestMethod]
        public void VariantA_RandomEdge()
        {
            double x = 7.38905609893065; // e^2
            Assert.AreEqual(Math.Log(x), Derivatives.SecondDerivative_VariantA(x), 1e-12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VariantA_Zero_Throws()
        {
            Derivatives.SecondDerivative_VariantA(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VariantA_Negative_Throws()
        {
            Derivatives.SecondDerivative_VariantA(-1);
        }

        // 15 tests for Variant V (SecondDerivative_VariantV)

        [TestMethod]
        public void VariantV_At0_Returns0()
        {
            Assert.AreEqual(0, Derivatives.SecondDerivative_VariantV(0), 1e-12);
        }

        [TestMethod]
        public void VariantV_AtPi_ReturnsPiSin3Pi()
        {
            var expected = Math.PI * Math.Sin(3 * Math.PI);
            Assert.AreEqual(expected, Derivatives.SecondDerivative_VariantV(Math.PI), 1e-12);
        }

        [TestMethod]
        public void VariantV_SmallValue()
        {
            double x = 0.1;
            Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
        }

        [TestMethod]
        public void VariantV_NegativeX()
        {
            double x = -0.5;
            Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
        }

        [TestMethod]
        public void VariantV_PiOver6()
        {
            double x = Math.PI / 6;
            Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
        }

        [TestMethod]
        public void VariantV_PiOver2()
        {
            double x = Math.PI / 2;
            Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
        }

        [TestMethod]
        public void VariantV_LargeX()
        {
            double x = 1000;
            Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
        }

        [TestMethod]
        public void VariantV_NearZero()
        {
            double x = 1e-6;
            Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
        }

        [TestMethod]
        public void VariantV_Random1()
        {
            var rnd = new Random(3);
            for (int i = 0; i < 5; i++)
            {
                double x = (rnd.NextDouble() - 0.5) * 20;
                Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
            }
        }

        [TestMethod]
        public void VariantV_Random2()
        {
            var rnd = new Random(4);
            for (int i = 0; i < 5; i++)
            {
                double x = (rnd.NextDouble() - 0.5) * 200;
                Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
            }
        }

        [TestMethod]
        public void VariantV_MultipleSmall()
        {
            for (int i = 1; i <= 10; i++)
            {
                double x = i * 0.1;
                Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
            }
        }

        [TestMethod]
        public void VariantV_MultipleNegatives()
        {
            for (int i = 1; i <= 10; i++)
            {
                double x = -i * 0.2;
                Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
            }
        }

        [TestMethod]
        public void VariantV_SinZeroCrossings()
        {
            // values where sin(3x)=0 -> x = k*pi/3
            double x = Math.PI/3.0;
            Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
            x = 2*Math.PI/3.0;
            Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
        }

        [TestMethod]
        public void VariantV_MultiplesOfPiOver6()
        {
            double x = Math.PI/6.0;
            Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
            x = Math.PI/2.0;
            Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
        }

        [TestMethod]
        public void VariantV_LargeNegative()
        {
            double x = -1000;
            Assert.AreEqual(x * Math.Sin(3 * x), Derivatives.SecondDerivative_VariantV(x), 1e-12);
        }
    }
}
