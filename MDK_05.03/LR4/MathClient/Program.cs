using MathClient;
var client = new MathApiClient("http://localhost:5000");

// Проверка доступности сервера
Console.WriteLine("Проверка подключения к серверу...");
bool isAvailable = await client.IsServerAvailableAsync();

if (!isAvailable)
{
    Console.WriteLine("Сервер недоступен. Убедитесь, что MathServer запущен.");
    return;
}

try
{
    // Задача 38: Вычисление интеграла
    Console.WriteLine("Задача 38: Вычисление интеграла");
    double integralResult = await client.PostIntegralAsync(2, 0);
    Console.WriteLine($"Интеграл от 0 до 2: {integralResult:F6}");
    Console.WriteLine();

    // Задача 43: Дифференциальное уравнение y'' - 4y' + 29y = 0
    Console.WriteLine("Задача 43: Дифференциальное уравнение y'' - 4y' + 29y = 0");
    double diffEq43Result = await client.PostDiffEq43Async(1, 1, 0);
    Console.WriteLine($"Решение при x=1, C1=1, C2=0: {diffEq43Result:F6}");
    
    bool verified43 = await client.VerifyDiffEq43Async(1, 1, 0);
    Console.WriteLine($"Проверка решения: {(verified43 ? "✓ Корректно" : "✗ Ошибка")}");
    Console.WriteLine();

    // Задача 44: Дифференциальное уравнение x^2*y'' + xy' + 1/x^2 = 0
    Console.WriteLine("Задача 44: Дифференциальное уравнение x^2*y'' + xy' + 1/x^2 = 0");
    double diffEq44Result = await client.PostDiffEq44Async(2, 1, 1);
    Console.WriteLine($"Решение при x=2, C1=1, C2=1: {diffEq44Result:F6}");
    
    bool verified44 = await client.VerifyDiffEq44Async(2, 1, 1);
    Console.WriteLine($"Проверка решения: {(verified44 ? "✓ Корректно" : "✗ Ошибка")}");
    Console.WriteLine();

    // Дополнительные вычисления
    Console.WriteLine("Дополнительные вычисления");
    double derivative = await client.GetIntegralDerivativeAsync(1.5);
    Console.WriteLine($"Производная интеграла при x=1.5: {derivative:F6}");
    
    double numericalIntegral = await client.GetIntegralNumericalAsync(2, 0, 10000);
    Console.WriteLine($"Численный интеграл от 0 до 2: {numericalIntegral:F6}");
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}
finally
{
    client.Dispose();
}

