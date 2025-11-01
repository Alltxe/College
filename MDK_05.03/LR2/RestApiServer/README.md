# REST API Server - Документация

## Описание проекта

Это REST API сервер, реализующий функциональность сортировки данных. Сервер построен на ASP.NET Core 9.0 и следует принципам архитектуры REST.

## Архитектура REST API

### Endpoint: POST /sort

**URL**: `http://localhost:5067/sort` (или другой порт, указанный при запуске)

**Метод**: POST

**Content-Type**: application/json

**Описание**: Сортирует список словарей по ключам. Поддерживает числовую и лексикографическую сортировку.

### Формат запроса

```json
[
  { "5": "five" },
  { "2": "two" },
  { "8": "eight" },
  { "1": "one" }
]
```

### Формат ответа

**Успешный ответ (200 OK)**:
```json
[
  { "1": "one" },
  { "2": "two" },
  { "5": "five" },
  { "8": "eight" }
]
```

**Ошибка (400 Bad Request)**:
```json
"Input data cannot be null."
```

## Особенности реализации

1. **Алгоритм сортировки**: Используется сортировка Шелла (Shell Sort) из библиотеки `LabsShareLibrary.Lab2`
2. **Типы ключей**: 
   - Числовые ключи сортируются численно
   - Строковые ключи сортируются лексикографически
   - Смешанные типы поддерживаются
3. **Обработка особых случаев**:
   - Пустые списки
   - Null значения (возвращает BadRequest)
   - Одиночные элементы
   - Дубликаты

## Запуск сервера

```powershell
cd c:\projects\College\MDK_05.03\LR2\RestApiServer
dotnet run
```

Сервер будет доступен по адресу: `http://localhost:5067` (или другой порт, указанный в консоли)

## Тестирование API

### Запуск unit тестов

```powershell
cd c:\projects\College\MDK_05.03\LR2\RestApiServer.Tests
dotnet test
```

### Список тестов (всего 15)

1. **Post_SortNumericKeys_ReturnsOkWithSortedData** - Проверка сортировки числовых ключей
2. **Post_SortStringKeys_ReturnsOkWithSortedData** - Проверка сортировки строковых ключей
3. **Post_EmptyList_ReturnsOkWithEmptyList** - Проверка обработки пустого списка
4. **Post_NullData_ReturnsBadRequest** - Проверка обработки null данных
5. **Post_SingleElement_ReturnsOkWithSameElement** - Проверка с одним элементом
6. **Post_MixedNumericAndStringKeys_ReturnsOkWithSortedData** - Смешанные типы ключей
7. **Post_DuplicateKeys_ReturnsOkWithAllElements** - Проверка с дубликатами
8. **Post_LargeNumbers_ReturnsOkWithSortedData** - Сортировка больших чисел
9. **Post_NegativeNumbers_ReturnsOkWithSortedData** - Отрицательные числа
10. **Post_DecimalNumbers_ReturnsOkWithSortedData** - Дробные числа
11. **Post_ValidData_ReturnsJsonContentType** - Проверка Content-Type
12. **Post_EmptyDictionaries_ReturnsOk** - Пустые словари
13. **Post_SpecialCharactersInKeys_ReturnsOkWithSortedData** - Специальные символы
14. **Post_LargeDataSet_ReturnsOkInReasonableTime** - Тест производительности (100 элементов)
15. **Post_SameDataTwice_ReturnsSameResult** - Проверка идемпотентности

### Примеры использования с curl

**Сортировка числовых ключей**:
```powershell
curl -X POST http://localhost:5067/sort `
  -H "Content-Type: application/json" `
  -d '[{"5":"five"},{"2":"two"},{"8":"eight"},{"1":"one"}]'
```

**Сортировка строковых ключей**:
```powershell
curl -X POST http://localhost:5067/sort `
  -H "Content-Type: application/json" `
  -d '[{"zebra":"z"},{"apple":"a"},{"mango":"m"}]'
```

## Структура проекта

```
RestApiServer/
├── Controllers/
│   └── SortController.cs      # REST API контроллер
├── Program.cs                  # Точка входа приложения
├── RestApiServer.csproj        # Файл проекта
└── README.md                   # Документация

RestApiServer.Tests/
├── SortControllerTests.cs      # Unit тесты для API
└── RestApiServer.Tests.csproj  # Файл тестового проекта
```

## Зависимости

- **Microsoft.AspNetCore.OpenApi** (9.0.9) - Поддержка OpenAPI/Swagger
- **Microsoft.AspNetCore.Mvc.Testing** (9.0.10) - Тестирование REST API
- **LabsShareLibrary** - Библиотека с алгоритмом сортировки

## Принципы REST, реализованные в API

1. **Stateless** - Каждый запрос независим и содержит всю необходимую информацию
2. **Client-Server** - Разделение клиента и сервера
3. **Uniform Interface** - Единообразный интерфейс взаимодействия
4. **JSON формат** - Стандартный формат обмена данными
5. **HTTP методы** - Использование POST для операций создания/обработки
6. **Коды ответов** - Правильное использование HTTP статус-кодов (200, 400)

## Возможные улучшения

1. Добавление поддержки GET /sort с параметрами в query string
2. Реализация пагинации для больших наборов данных
3. Добавление аутентификации и авторизации
4. Логирование запросов и ответов
5. Добавление Swagger UI для документации API
6. Реализация кэширования результатов
7. Добавление rate limiting для защиты от перегрузки
