using NUnit.Framework;
using MathClient;
using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MathClient.Tests
{
    // 30 unit-тестов для MathApiClient (NUnit)
    [TestFixture]
    public class MathApiClientTests
    {
        private Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private HttpClient _httpClient;
        private MathApiClient _client;

        [SetUp]
        public void Setup()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_mockHttpMessageHandler.Object);
            _client = new MathApiClient(_httpClient, "http://localhost:5000");
        }

        [TearDown]
        public void TearDown()
        {
            _client?.Dispose();
            _httpClient?.Dispose();
        }

        private void SetupMockResponse(HttpStatusCode statusCode, string content)
        {
            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(content, Encoding.UTF8, "application/json")
                });
        }

        #region Тесты GetIntegralAsync (Tests 1-5)

        [Test]
        public async Task Test01_GetIntegralAsync_ValidParameters_ReturnsCorrectValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "5.5");

            // Act
            double result = await _client.GetIntegralAsync(2, 0);

            // Assert
            Assert.That(result, Is.EqualTo(5.5).Within(0.01));
        }

        [Test]
        public async Task Test02_GetIntegralAsync_WithLowerLimit_ReturnsCorrectValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "3.14");

            // Act
            double result = await _client.GetIntegralAsync(3, 1);

            // Assert
            Assert.That(result, Is.EqualTo(3.14).Within(0.01));
        }

        [Test]
        public async Task Test03_GetIntegralAsync_ServerError_ThrowsException()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.InternalServerError, "");

            // Act & Assert
            Assert.ThrowsAsync<HttpRequestException>(async () => 
                await _client.GetIntegralAsync(1, 0));
        }

        [Test]
        public async Task Test04_GetIntegralAsync_ZeroValue_ReturnsZero()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "0.0");

            // Act
            double result = await _client.GetIntegralAsync(0, 0);

            // Assert
            Assert.That(result, Is.EqualTo(0).Within(0.01));
        }

        [Test]
        public async Task Test05_GetIntegralAsync_NegativeResult_ReturnsNegativeValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "-2.5");

            // Act
            double result = await _client.GetIntegralAsync(1, 2);

            // Assert
            Assert.That(result, Is.LessThan(0));
        }

        #endregion

        #region Тесты PostIntegralAsync (Tests 6-10)

        [Test]
        public async Task Test06_PostIntegralAsync_ValidParameters_ReturnsCorrectValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "7.89");

            // Act
            double result = await _client.PostIntegralAsync(2, 0);

            // Assert
            Assert.That(result, Is.EqualTo(7.89).Within(0.01));
        }

        [Test]
        public async Task Test07_PostIntegralAsync_WithLowerLimit_ReturnsCorrectValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "4.2");

            // Act
            double result = await _client.PostIntegralAsync(5, 2);

            // Assert
            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public async Task Test08_PostIntegralAsync_LargeValues_ReturnsFiniteValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "999.99");

            // Act
            double result = await _client.PostIntegralAsync(100, 0);

            // Assert
            Assert.That(double.IsFinite(result), Is.True);
        }

        [Test]
        public async Task Test09_PostIntegralAsync_BadRequest_ThrowsException()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.BadRequest, "Invalid parameters");

            // Act & Assert
            Assert.ThrowsAsync<HttpRequestException>(async () => 
                await _client.PostIntegralAsync(double.NaN, 0));
        }

        [Test]
        public async Task Test10_PostIntegralAsync_PositiveResult_IsPositive()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "12.34");

            // Act
            double result = await _client.PostIntegralAsync(3, 1);

            // Assert
            Assert.That(result, Is.Positive);
        }

        #endregion

        #region Тесты GetDiffEq43Async (Tests 11-15)

        [Test]
        public async Task Test11_GetDiffEq43Async_ValidParameters_ReturnsCorrectValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "1.234");

            // Act
            double result = await _client.GetDiffEq43Async(1, 1, 0);

            // Assert
            Assert.That(result, Is.EqualTo(1.234).Within(0.01));
        }

        [Test]
        public async Task Test12_GetDiffEq43Async_AtZero_ReturnsC1()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "2.0");

            // Act
            double result = await _client.GetDiffEq43Async(0, 2, 0);

            // Assert
            Assert.That(result, Is.EqualTo(2.0).Within(0.01));
        }

        [Test]
        public async Task Test13_GetDiffEq43Async_NegativeX_ReturnsFiniteValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "-0.567");

            // Act
            double result = await _client.GetDiffEq43Async(-1, 1, 1);

            // Assert
            Assert.That(double.IsFinite(result), Is.True);
        }

        [Test]
        public async Task Test14_GetDiffEq43Async_BothConstants_ReturnsValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "5.678");

            // Act
            double result = await _client.GetDiffEq43Async(2, 3, 4);

            // Assert
            Assert.That(result, Is.Not.Zero);
        }

        [Test]
        public async Task Test15_GetDiffEq43Async_ServerError_ThrowsException()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.InternalServerError, "");

            // Act & Assert
            Assert.ThrowsAsync<HttpRequestException>(async () => 
                await _client.GetDiffEq43Async(1, 1, 1));
        }

        #endregion

        #region Тесты PostDiffEq43Async (Tests 16-18)

        [Test]
        public async Task Test16_PostDiffEq43Async_ValidParameters_ReturnsCorrectValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "8.901");

            // Act
            double result = await _client.PostDiffEq43Async(1.5, 1, 1);

            // Assert
            Assert.That(result, Is.EqualTo(8.901).Within(0.01));
        }

        [Test]
        public async Task Test17_PostDiffEq43Async_ZeroConstants_ReturnsZero()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "0.0");

            // Act
            double result = await _client.PostDiffEq43Async(5, 0, 0);

            // Assert
            Assert.That(result, Is.Zero.Within(0.01));
        }

        [Test]
        public async Task Test18_PostDiffEq43Async_LargeX_ReturnsFiniteValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "123.456");

            // Act
            double result = await _client.PostDiffEq43Async(10, 1, 1);

            // Assert
            Assert.That(double.IsFinite(result), Is.True);
        }

        #endregion

        #region Тесты GetDiffEq44Async (Tests 19-21)

        [Test]
        public async Task Test19_GetDiffEq44Async_ValidParameters_ReturnsCorrectValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "2.345");

            // Act
            double result = await _client.GetDiffEq44Async(2, 1, 1);

            // Assert
            Assert.That(result, Is.EqualTo(2.345).Within(0.01));
        }

        [Test]
        public async Task Test20_GetDiffEq44Async_AtOne_ReturnsC1()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "1.5");

            // Act
            double result = await _client.GetDiffEq44Async(1, 1.5, 0);

            // Assert
            Assert.That(result, Is.EqualTo(1.5).Within(0.01));
        }

        [Test]
        public async Task Test21_GetDiffEq44Async_SmallX_ReturnsFiniteValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "0.789");

            // Act
            double result = await _client.GetDiffEq44Async(0.1, 1, 1);

            // Assert
            Assert.That(double.IsFinite(result), Is.True);
        }

        #endregion

        #region Тесты PostDiffEq44Async (Tests 22-24)

        [Test]
        public async Task Test22_PostDiffEq44Async_ValidParameters_ReturnsCorrectValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "3.456");

            // Act
            double result = await _client.PostDiffEq44Async(3, 2, 1);

            // Assert
            Assert.That(result, Is.EqualTo(3.456).Within(0.01));
        }

        [Test]
        public async Task Test23_PostDiffEq44Async_AtE_ReturnsFiniteValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "1.111");

            // Act
            double result = await _client.PostDiffEq44Async(Math.E, 1, 1);

            // Assert
            Assert.That(double.IsFinite(result), Is.True);
        }

        [Test]
        public async Task Test24_PostDiffEq44Async_BadRequest_ThrowsException()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.BadRequest, "x must be positive");

            // Act & Assert
            Assert.ThrowsAsync<HttpRequestException>(async () => 
                await _client.PostDiffEq44Async(-1, 1, 1));
        }

        #endregion

        #region Тесты Verify Methods (Tests 25-27)

        [Test]
        public async Task Test25_VerifyDiffEq43Async_ValidSolution_ReturnsTrue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "true");

            // Act
            bool result = await _client.VerifyDiffEq43Async(1, 1, 1);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task Test26_VerifyDiffEq44Async_ValidSolution_ReturnsTrue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "true");

            // Act
            bool result = await _client.VerifyDiffEq44Async(2, 1, 1);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task Test27_VerifyDiffEq44Async_InvalidInput_ReturnsFalse()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "false");

            // Act
            bool result = await _client.VerifyDiffEq44Async(0.5, 100, 200);

            // Assert
            Assert.That(result, Is.False);
        }

        #endregion

        #region Тесты вспомогательных методов (Tests 28-30)

        [Test]
        public async Task Test28_GetIntegralDerivativeAsync_ValidParameter_ReturnsFiniteValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "4.567");

            // Act
            double result = await _client.GetIntegralDerivativeAsync(1.5);

            // Assert
            Assert.That(double.IsFinite(result), Is.True);
        }

        [Test]
        public async Task Test29_GetIntegralNumericalAsync_ValidParameters_ReturnsFiniteValue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "10.123");

            // Act
            double result = await _client.GetIntegralNumericalAsync(2, 0, 1000);

            // Assert
            Assert.That(double.IsFinite(result), Is.True);
        }

        [Test]
        public async Task Test30_IsServerAvailableAsync_ServerUp_ReturnsTrue()
        {
            // Arrange
            SetupMockResponse(HttpStatusCode.OK, "1.0");

            // Act
            bool result = await _client.IsServerAvailableAsync();

            // Assert
            Assert.That(result, Is.True);
        }

        #endregion
    }
}
