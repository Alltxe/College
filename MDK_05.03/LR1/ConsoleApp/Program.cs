using LabsShareLibrary;

Console.WriteLine("Введите количество элементов для сортировки:");
int count = int.Parse(Console.ReadLine() ?? "0");

List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

for (int i = 0; i < count; i++)
{
    Console.WriteLine($"Введите ключ для элемента {i + 1}:");
    string key = Console.ReadLine() ?? "";
    Console.WriteLine($"Введите значение для элемента {i + 1}:");
    string value = Console.ReadLine() ?? "";
    var dict = new Dictionary<string, string> { { key, value } };
    list.Add(dict);
}

Console.WriteLine("Исходный список:");
PrintList(list);

Lab2.Sort(list);

Console.WriteLine("Отсортированный список:");
PrintList(list);

static void PrintList(List<Dictionary<string, string>> list)
{
    foreach (var dict in list)
    {
        foreach (var kvp in dict)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
        Console.WriteLine();
    }
}
