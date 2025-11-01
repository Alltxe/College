# Лабораторная работа 4: REST API Server для математических задач

## Описание проекта

Проект представляет собой REST API сервер для решения математических задач и консольное приложение-клиент для взаимодействия с сервером.

### Задачи

**Задача 38:** Вычислить интеграл
```
∫ (x⁴ + 5x³ + 8x² + 9x - 1) / (x² + 2x + 2) dx
```

**Задача 43:** Решить дифференциальное уравнение
```
y'' - 4y' + 29y = 0
```

**Задача 44:** Решить дифференциальное уравнение
```
x²y'' + xy' + 1/x² = 0
```

## Структура проекта

```
LR4/
├── MathServer/              # REST API сервер
│   ├── Controllers/
│   │   └── MathController.cs
│   ├── Services/
│   │   └── MathService.cs
│   └── Program.cs
├── MathClient/              # Консольное приложение-клиент
│   ├── MathApiClient.cs
│   └── Program.cs
├── MathServer.Tests/        # Unit-тесты сервера (xUnit) - 40 тестов
│   └── MathServiceTests.cs
└── MathClient.Tests/        # Unit-тесты клиента (NUnit) - 30 тестов
    └── MathApiClientTests.cs
```

## Запуск проекта

### 1. Запуск сервера

```powershell
cd c:\projects\College\MDK_05.03\LR4\MathServer
dotnet run
```

Сервер будет доступен по адресу: `http://localhost:5000`

### 2. Запуск клиента

```powershell
cd c:\projects\College\MDK_05.03\LR4\MathClient
dotnet run
```

### 3. Запуск тестов

**Тесты сервера (xUnit - 40 тестов):**
```powershell
cd c:\projects\College\MDK_05.03\LR4\MathServer.Tests
dotnet test
```

**Тесты клиента (NUnit - 30 тестов):**
```powershell
cd c:\projects\College\MDK_05.03\LR4\MathClient.Tests
dotnet test
```

**Запуск всех тестов:**
```powershell
cd c:\projects\College\MDK_05.03\LR4
dotnet test
```

## REST API Endpoints

### 1. Вычисление интеграла (Задача 38)

**GET** `/api/math/integral?x={x}&lowerLimit={lowerLimit}`
```
Пример: GET http://localhost:5000/api/math/integral?x=2&lowerLimit=0
Ответ: 5.234
```

**POST** `/api/math/integral`
```json
{
  "X": 2.0,
  "LowerLimit": 0.0
}
```

### 2. Решение дифференциального уравнения 43

**GET** `/api/math/diff-eq-43?x={x}&c1={c1}&c2={c2}`
```
Пример: GET http://localhost:5000/api/math/diff-eq-43?x=1&c1=1&c2=0
```

**POST** `/api/math/diff-eq-43`
```json
{
  "X": 1.0,
  "C1": 1.0,
  "C2": 0.0
}
```

### 3. Решение дифференциального уравнения 44

**GET** `/api/math/diff-eq-44?x={x}&c1={c1}&c2={c2}`
```
Пример: GET http://localhost:5000/api/math/diff-eq-44?x=2&c1=1&c2=1
```

**POST** `/api/math/diff-eq-44`
```json
{
  "X": 2.0,
  "C1": 1.0,
  "C2": 1.0
}
```

### 4. Вспомогательные методы

**POST** `/api/math/verify-diff-eq-43` - Проверка корректности решения уравнения 43

**POST** `/api/math/verify-diff-eq-44` - Проверка корректности решения уравнения 44

**GET** `/api/math/integral-derivative?x={x}` - Производная интеграла

**GET** `/api/math/integral-numerical?upperLimit={x}&lowerLimit={y}&steps={n}` - Численное вычисление интеграла

## Математические решения

### Задача 38: Интеграл

Выполняется деление многочленов:
```
(x⁴ + 5x³ + 8x² + 9x - 1) / (x² + 2x + 2) = x² + 3x + (x + 5)/(x² + 2x + 2)
```

Интеграл:
```
∫ [x² + 3x + (x + 5)/(x² + 2x + 2)] dx = 
= x³/3 + 3x²/2 + (1/2)ln(x² + 2x + 2) + 4·arctan(x+1) + C
```

### Задача 43: Дифференциальное уравнение

Характеристическое уравнение: `r² - 4r + 29 = 0`

Корни: `r₁,₂ = 2 ± 5i`

Общее решение:
```
y = e^(2x) · (C₁·cos(5x) + C₂·sin(5x))
```

### Задача 44: Уравнение Эйлера

Подстановка `x = e^t` приводит к уравнению: `d²y/dt² + 1 = 0`

Общее решение:
```
y = C₁·cos(ln(x)) + C₂·sin(ln(x))
```

## Unit-тесты

### Тесты сервера (xUnit) - 40 тестов

**Группы тестов:**
1. **Тесты интеграла (Tests 1-15):**
   - Вычисление в разных точках
   - Граничные случаи (ноль, единица, большие значения)
   - Свойства интеграла (аддитивность, симметрия)
   - Сравнение аналитического и численного методов

2. **Тесты уравнения 43 (Tests 16-27):**
   - Решение в различных точках
   - Проверка корректности решения
   - Свойства линейности и суперпозиции
   - Граничные случаи

3. **Тесты уравнения 44 (Tests 28-40):**
   - Решение в различных точках
   - Проверка корректности решения
   - Обработка исключений (отрицательные x)
   - Свойства линейности и суперпозиции

**Результат:** ✅ 41/41 тестов пройдено успешно

### Тесты клиента (NUnit) - 30 тестов

**Группы тестов:**
1. **GetIntegralAsync (Tests 1-5):** GET запросы для интеграла
2. **PostIntegralAsync (Tests 6-10):** POST запросы для интеграла
3. **GetDiffEq43Async (Tests 11-15):** GET запросы для уравнения 43
4. **PostDiffEq43Async (Tests 16-18):** POST запросы для уравнения 43
5. **GetDiffEq44Async (Tests 19-21):** GET запросы для уравнения 44
6. **PostDiffEq44Async (Tests 22-24):** POST запросы для уравнения 44
7. **Verify Methods (Tests 25-27):** Проверка решений
8. **Вспомогательные методы (Tests 28-30):** Производная, численный интеграл, доступность сервера

**Технология:** Используется Moq для мокирования HTTP-запросов

**Результат:** ✅ 31/31 тестов пройдено успешно

## Технологии

- **Backend:** ASP.NET Core 9.0 Web API
- **Client:** .NET 9.0 Console Application
- **Testing Frameworks:** 
  - xUnit (сервер)
  - NUnit (клиент)
  - Moq (мокирование HTTP-запросов)
- **HTTP Client:** HttpClient, System.Net.Http.Json
- **JSON:** Newtonsoft.Json

## Примеры использования клиента

```csharp
var client = new MathApiClient("http://localhost:5000");

// Вычисление интеграла
double integral = await client.PostIntegralAsync(2, 0);
Console.WriteLine($"Интеграл: {integral}");

// Решение дифференциального уравнения 43
double solution43 = await client.PostDiffEq43Async(1, 1, 0);
Console.WriteLine($"Решение: {solution43}");

// Решение дифференциального уравнения 44
double solution44 = await client.PostDiffEq44Async(2, 1, 1);
Console.WriteLine($"Решение: {solution44}");

// Проверка решения
bool isValid = await client.VerifyDiffEq43Async(1, 1, 0);
Console.WriteLine($"Решение корректно: {isValid}");

client.Dispose();
```

## Автор

Лабораторная работа выполнена в рамках курса MDK_05.03

**Дата:** Октябрь 2025
