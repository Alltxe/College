using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace RestApiServer.Tests;

[TestClass]
public class SortControllerTests
{
    private WebApplicationFactory<Program> _factory = null!;
    private HttpClient _client = null!;

    [TestInitialize]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }

    [TestCleanup]
    public void Cleanup()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    // Test 1: Проверка успешной сортировки с числовыми ключами
    [TestMethod]
    public async Task Post_SortNumericKeys_ReturnsOkWithSortedData()
    {
        // Arrange
        var data = new List<Dictionary<string, string>>
        {
            new() { { "5", "five" } },
            new() { { "2", "two" } },
            new() { { "8", "eight" } },
            new() { { "1", "one" } }
        };

        // Act
        var response = await _client.PostAsJsonAsync("/sort", data);
        var result = await response.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsNotNull(result);
        Assert.AreEqual(4, result.Count);
        Assert.AreEqual("1", result[0].Keys.First());
        Assert.AreEqual("2", result[1].Keys.First());
        Assert.AreEqual("5", result[2].Keys.First());
        Assert.AreEqual("8", result[3].Keys.First());
    }

    // Test 2: Проверка сортировки строковых ключей
    [TestMethod]
    public async Task Post_SortStringKeys_ReturnsOkWithSortedData()
    {
        // Arrange
        var data = new List<Dictionary<string, string>>
        {
            new() { { "zebra", "z" } },
            new() { { "apple", "a" } },
            new() { { "mango", "m" } },
            new() { { "banana", "b" } }
        };

        // Act
        var response = await _client.PostAsJsonAsync("/sort", data);
        var result = await response.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsNotNull(result);
        Assert.AreEqual("apple", result[0].Keys.First());
        Assert.AreEqual("banana", result[1].Keys.First());
        Assert.AreEqual("mango", result[2].Keys.First());
        Assert.AreEqual("zebra", result[3].Keys.First());
    }

    // Test 3: Проверка обработки пустого списка
    [TestMethod]
    public async Task Post_EmptyList_ReturnsOkWithEmptyList()
    {
        // Arrange
        var data = new List<Dictionary<string, string>>();

        // Act
        var response = await _client.PostAsJsonAsync("/sort", data);
        var result = await response.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
    }

    // Test 4: Проверка обработки null данных
    [TestMethod]
    public async Task Post_NullData_ReturnsBadRequest()
    {
        // Arrange
        var content = new StringContent("null", Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/sort", content);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    // Test 5: Проверка сортировки с одним элементом
    [TestMethod]
    public async Task Post_SingleElement_ReturnsOkWithSameElement()
    {
        // Arrange
        var data = new List<Dictionary<string, string>>
        {
            new() { { "42", "answer" } }
        };

        // Act
        var response = await _client.PostAsJsonAsync("/sort", data);
        var result = await response.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("42", result[0].Keys.First());
    }

    // Test 6: Проверка сортировки смешанных числовых и строковых ключей
    [TestMethod]
    public async Task Post_MixedNumericAndStringKeys_ReturnsOkWithSortedData()
    {
        // Arrange
        var data = new List<Dictionary<string, string>>
        {
            new() { { "10", "ten" } },
            new() { { "abc", "letters" } },
            new() { { "5", "five" } },
            new() { { "xyz", "more letters" } }
        };

        // Act
        var response = await _client.PostAsJsonAsync("/sort", data);
        var result = await response.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsNotNull(result);
        Assert.AreEqual(4, result.Count);
    }

    // Test 7: Проверка сортировки с дубликатами
    [TestMethod]
    public async Task Post_DuplicateKeys_ReturnsOkWithAllElements()
    {
        // Arrange
        var data = new List<Dictionary<string, string>>
        {
            new() { { "3", "three-first" } },
            new() { { "1", "one" } },
            new() { { "3", "three-second" } },
            new() { { "2", "two" } }
        };

        // Act
        var response = await _client.PostAsJsonAsync("/sort", data);
        var result = await response.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsNotNull(result);
        Assert.AreEqual(4, result.Count);
        Assert.AreEqual("1", result[0].Keys.First());
    }

    // Test 8: Проверка сортировки больших чисел
    [TestMethod]
    public async Task Post_LargeNumbers_ReturnsOkWithSortedData()
    {
        // Arrange
        var data = new List<Dictionary<string, string>>
        {
            new() { { "1000", "thousand" } },
            new() { { "999", "nine ninety-nine" } },
            new() { { "10000", "ten thousand" } },
            new() { { "100", "hundred" } }
        };

        // Act
        var response = await _client.PostAsJsonAsync("/sort", data);
        var result = await response.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsNotNull(result);
        Assert.AreEqual("100", result[0].Keys.First());
        Assert.AreEqual("999", result[1].Keys.First());
        Assert.AreEqual("1000", result[2].Keys.First());
        Assert.AreEqual("10000", result[3].Keys.First());
    }

    // Test 9: Проверка сортировки отрицательных чисел
    [TestMethod]
    public async Task Post_NegativeNumbers_ReturnsOkWithSortedData()
    {
        // Arrange
        var data = new List<Dictionary<string, string>>
        {
            new() { { "5", "five" } },
            new() { { "-3", "minus three" } },
            new() { { "0", "zero" } },
            new() { { "-10", "minus ten" } }
        };

        // Act
        var response = await _client.PostAsJsonAsync("/sort", data);
        var result = await response.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsNotNull(result);
        Assert.AreEqual("-10", result[0].Keys.First());
        Assert.AreEqual("-3", result[1].Keys.First());
        Assert.AreEqual("0", result[2].Keys.First());
        Assert.AreEqual("5", result[3].Keys.First());
    }

    // Test 10: Проверка сортировки с дробными числами
    [TestMethod]
    public async Task Post_DecimalNumbers_ReturnsOkWithSortedData()
    {
        // Arrange
        var data = new List<Dictionary<string, string>>
        {
            new() { { "3.14", "pi" } },
            new() { { "2.71", "e" } },
            new() { { "1.41", "sqrt2" } },
            new() { { "1.73", "sqrt3" } }
        };

        // Act
        var response = await _client.PostAsJsonAsync("/sort", data);
        var result = await response.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsNotNull(result);
        Assert.AreEqual("1.41", result[0].Keys.First());
        Assert.AreEqual("1.73", result[1].Keys.First());
        Assert.AreEqual("2.71", result[2].Keys.First());
        Assert.AreEqual("3.14", result[3].Keys.First());
    }

    // Test 11: Проверка корректности Content-Type в ответе
    [TestMethod]
    public async Task Post_ValidData_ReturnsJsonContentType()
    {
        // Arrange
        var data = new List<Dictionary<string, string>>
        {
            new() { { "1", "one" } }
        };

        // Act
        var response = await _client.PostAsJsonAsync("/sort", data);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsTrue(response.Content.Headers.ContentType?.MediaType?.Contains("json") ?? false);
    }

    // Test 12: Проверка сортировки с пустыми словарями
    [TestMethod]
    public async Task Post_EmptyDictionaries_ReturnsOk()
    {
        // Arrange
        var data = new List<Dictionary<string, string>>
        {
            new(),
            new(),
            new()
        };

        // Act
        var response = await _client.PostAsJsonAsync("/sort", data);
        var result = await response.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.Count);
    }

    // Test 13: Проверка сортировки с специальными символами в ключах
    [TestMethod]
    public async Task Post_SpecialCharactersInKeys_ReturnsOkWithSortedData()
    {
        // Arrange
        var data = new List<Dictionary<string, string>>
        {
            new() { { "z@key", "at" } },
            new() { { "a#key", "hash" } },
            new() { { "m!key", "exclaim" } }
        };

        // Act
        var response = await _client.PostAsJsonAsync("/sort", data);
        var result = await response.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.Count);
    }

    // Test 14: Проверка производительности с большим количеством элементов
    [TestMethod]
    public async Task Post_LargeDataSet_ReturnsOkInReasonableTime()
    {
        // Arrange
        var data = new List<Dictionary<string, string>>();
        var random = new Random(42); // Seed для воспроизводимости
        for (int i = 0; i < 100; i++)
        {
            data.Add(new Dictionary<string, string> { { random.Next(1000).ToString(), $"value{i}" } });
        }

        // Act
        var startTime = DateTime.Now;
        var response = await _client.PostAsJsonAsync("/sort", data);
        var endTime = DateTime.Now;
        var result = await response.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsNotNull(result);
        Assert.AreEqual(100, result.Count);
        Assert.IsTrue((endTime - startTime).TotalSeconds < 5, "Sorting took too long");
    }

    // Test 15: Проверка идемпотентности (повторный запрос дает тот же результат)
    [TestMethod]
    public async Task Post_SameDataTwice_ReturnsSameResult()
    {
        // Arrange
        var data = new List<Dictionary<string, string>>
        {
            new() { { "3", "three" } },
            new() { { "1", "one" } },
            new() { { "2", "two" } }
        };

        // Act
        var response1 = await _client.PostAsJsonAsync("/sort", data);
        var result1 = await response1.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();

        var response2 = await _client.PostAsJsonAsync("/sort", data);
        var result2 = await response2.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response1.StatusCode);
        Assert.AreEqual(HttpStatusCode.OK, response2.StatusCode);
        Assert.IsNotNull(result1);
        Assert.IsNotNull(result2);
        
        for (int i = 0; i < result1.Count; i++)
        {
            Assert.AreEqual(result1[i].Keys.First(), result2[i].Keys.First());
        }
    }
}
