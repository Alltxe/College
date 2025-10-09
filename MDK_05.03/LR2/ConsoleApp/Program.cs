using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;


var handler = new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
};
using var client = new HttpClient(handler);

client.BaseAddress = new Uri("http://localhost:5067/");

Console.WriteLine("Введите количество элементов для сортировки:");
if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
{
    Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
    return;
}

var list = new List<Dictionary<string, string>>();

for (int i = 0; i < count; i++)
{
    Console.WriteLine($"Введите ключ для элемента {i + 1}:");
    string key = Console.ReadLine() ?? "";
    Console.WriteLine($"Введите значение для элемента {i + 1}:");
    string value = Console.ReadLine() ?? "";
    var dict = new Dictionary<string, string> { { key, value } };
    list.Add(dict);
}

Console.WriteLine("\nИсходный список:");
PrintList(list);

try
{
    await CallSortApiAsync(list);
}
catch (HttpRequestException e)
{
    Console.WriteLine($"\nОшибка HTTP-запроса: {e.Message}");
    Console.WriteLine("Убедитесь, что проект RestApiServer запущен и доступен по указанному адресу.");
}
catch (Exception e)
{
    Console.WriteLine($"\nПроизошла непредвиденная ошибка: {e.Message}");
}


async Task CallSortApiAsync(List<Dictionary<string, string>> data)
{
    Console.WriteLine("\nОтправка данных на сервер для сортировки...");

    HttpResponseMessage response = await client.PostAsJsonAsync("Sort", data);

    if (response.IsSuccessStatusCode)
    {
        // Читаем отсортированный список из ответа
        var sortedList = await response.Content.ReadFromJsonAsync<List<Dictionary<string, string>>>();
        
        Console.WriteLine("\nОтсортированный список:");
        if (sortedList != null)
        {
            PrintList(sortedList);
        }
    }
    else
    {
        string errorContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Ошибка при вызове API: {response.StatusCode}");
        Console.WriteLine($"Ответ сервера: {errorContent}");
    }
}

static void PrintList(List<Dictionary<string, string>> list)
{
    foreach (var dict in list)
    {
        foreach (var kvp in dict)
        {
            Console.WriteLine($"- {kvp.Key}: {kvp.Value}");
        }
    }
    Console.WriteLine();
}
