using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MathClient
{
    // HTTP-клиент для взаимодействия с MathServer API
    public class MathApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public MathApiClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        public MathApiClient(HttpClient httpClient, string baseUrl = "http://localhost:5000")
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        // GET запрос для вычисления интеграла
        public async Task<double> GetIntegralAsync(double x, double lowerLimit = 0)
        {
            var response = await _httpClient.GetAsync($"/api/math/integral?x={x}&lowerLimit={lowerLimit}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<double>();
        }

        // POST запрос для вычисления интеграла
        public async Task<double> PostIntegralAsync(double x, double lowerLimit = 0)
        {
            var request = new { X = x, LowerLimit = lowerLimit };
            var response = await _httpClient.PostAsJsonAsync("/api/math/integral", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<double>();
        }

        // GET запрос для решения дифференциального уравнения 43
        public async Task<double> GetDiffEq43Async(double x, double c1, double c2)
        {
            var response = await _httpClient.GetAsync($"/api/math/diff-eq-43?x={x}&c1={c1}&c2={c2}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<double>();
        }

        // POST запрос для решения дифференциального уравнения 43
        public async Task<double> PostDiffEq43Async(double x, double c1, double c2)
        {
            var request = new { X = x, C1 = c1, C2 = c2 };
            var response = await _httpClient.PostAsJsonAsync("/api/math/diff-eq-43", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<double>();
        }

        // GET запрос для решения дифференциального уравнения 44
        public async Task<double> GetDiffEq44Async(double x, double c1, double c2)
        {
            var response = await _httpClient.GetAsync($"/api/math/diff-eq-44?x={x}&c1={c1}&c2={c2}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<double>();
        }

        // POST запрос для решения дифференциального уравнения 44
        public async Task<double> PostDiffEq44Async(double x, double c1, double c2)
        {
            var request = new { X = x, C1 = c1, C2 = c2 };
            var response = await _httpClient.PostAsJsonAsync("/api/math/diff-eq-44", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<double>();
        }

        // POST запрос для проверки решения уравнения 43
        public async Task<bool> VerifyDiffEq43Async(double x, double c1, double c2)
        {
            var request = new { X = x, C1 = c1, C2 = c2 };
            var response = await _httpClient.PostAsJsonAsync("/api/math/verify-diff-eq-43", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        // POST запрос для проверки решения уравнения 44
        public async Task<bool> VerifyDiffEq44Async(double x, double c1, double c2)
        {
            var request = new { X = x, C1 = c1, C2 = c2 };
            var response = await _httpClient.PostAsJsonAsync("/api/math/verify-diff-eq-44", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        // GET запрос для вычисления производной интеграла
        public async Task<double> GetIntegralDerivativeAsync(double x)
        {
            var response = await _httpClient.GetAsync($"/api/math/integral-derivative?x={x}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<double>();
        }

        // GET запрос для численного вычисления интеграла
        public async Task<double> GetIntegralNumericalAsync(double upperLimit, double lowerLimit = 0, int steps = 10000)
        {
            var response = await _httpClient.GetAsync(
                $"/api/math/integral-numerical?upperLimit={upperLimit}&lowerLimit={lowerLimit}&steps={steps}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<double>();
        }

        // Проверка доступности сервера
        public async Task<bool> IsServerAvailableAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/math/integral?x=1&lowerLimit=0");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
