using LabsShareLibrary;

namespace LabsShareLibrary.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestSort_EmptyList()
    {
        var list = new List<Dictionary<string, string>>();

        Lab2.Sort(list);

        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void TestSort_SingleElement()
    {
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "key1", "value1" } }
        };

        Lab2.Sort(list);

        Assert.AreEqual(1, list.Count);
        Assert.AreEqual("key1", list[0].Keys.First());
    }

    [TestMethod]
    public void TestSort_TwoElements_AlreadySorted()
    {
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "a", "1" } },
            new Dictionary<string, string> { { "b", "2" } }
        };

        Lab2.Sort(list);

        Assert.AreEqual("a", list[0].Keys.First());
        Assert.AreEqual("b", list[1].Keys.First());
    }

    [TestMethod]
    public void TestSort_TwoElements_ReverseSorted()
    {
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "b", "2" } },
            new Dictionary<string, string> { { "a", "1" } }
        };

        Lab2.Sort(list);

        Assert.AreEqual("a", list[0].Keys.First());
        Assert.AreEqual("b", list[1].Keys.First());
    }

    [TestMethod]
    public void TestSort_ThreeElements_AlreadySorted()
    {
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "a", "1" } },
            new Dictionary<string, string> { { "b", "2" } },
            new Dictionary<string, string> { { "c", "3" } }
        };

        Lab2.Sort(list);

        Assert.AreEqual("a", list[0].Keys.First());
        Assert.AreEqual("b", list[1].Keys.First());
        Assert.AreEqual("c", list[2].Keys.First());
    }

    [TestMethod]
    public void TestSort_ThreeElements_ReverseSorted()
    {
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "c", "3" } },
            new Dictionary<string, string> { { "b", "2" } },
            new Dictionary<string, string> { { "a", "1" } }
        };

        Lab2.Sort(list);

        Assert.AreEqual("a", list[0].Keys.First());
        Assert.AreEqual("b", list[1].Keys.First());
        Assert.AreEqual("c", list[2].Keys.First());
    }

    [TestMethod]
    public void TestSort_RandomOrder()
    {
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "z", "3" } },
            new Dictionary<string, string> { { "a", "1" } },
            new Dictionary<string, string> { { "m", "2" } }
        };

        Lab2.Sort(list);

        Assert.AreEqual("a", list[0].Keys.First());
        Assert.AreEqual("m", list[1].Keys.First());
        Assert.AreEqual("z", list[2].Keys.First());
    }

    [TestMethod]
    public void TestSort_Duplicates()
    {
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "a", "1" } },
            new Dictionary<string, string> { { "a", "2" } },
            new Dictionary<string, string> { { "a", "3" } }
        };

        Lab2.Sort(list);

        Assert.AreEqual("a", list[0].Keys.First());
        Assert.AreEqual("a", list[1].Keys.First());
        Assert.AreEqual("a", list[2].Keys.First());
    }

    [TestMethod]
    public void TestSort_NullKeys()
    {
        // словарь не может иметь null ключ, поэтому тестируем пустой словарь
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string>(),
            new Dictionary<string, string> { { "a", "1" } }
        };

        // Выполнение
        Lab2.Sort(list);

        // Проверка - пустой элемент должен быть первым
        Assert.AreEqual(0, list[0].Count);
        Assert.AreEqual("a", list[1].Keys.First());
    }

    [TestMethod]
    public void TestSort_EmptyKeys()
    {
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "", "1" } },
            new Dictionary<string, string> { { "a", "2" } }
        };
        Lab2.Sort(list);

        Assert.AreEqual("", list[0].Keys.First());
        Assert.AreEqual("a", list[1].Keys.First());
    }

    [TestMethod]
    public void TestSort_LargeList()
    {
        var list = new List<Dictionary<string, string>>();
        for (int i = 10; i >= 1; i--)
        {
            list.Add(new Dictionary<string, string> { { $"key{i}", $"value{i}" } });
        }
        Lab2.Sort(list);

        var expected = new[] { "key1", "key10", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], list[i].Keys.First());
        }
    }

    [TestMethod]
    public void TestSort_AllSame()
    {
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "a", "1" } },
            new Dictionary<string, string> { { "a", "2" } },
            new Dictionary<string, string> { { "a", "3" } }
        };
        Lab2.Sort(list);

        Assert.AreEqual("a", list[0].Keys.First());
        Assert.AreEqual("a", list[1].Keys.First());
        Assert.AreEqual("a", list[2].Keys.First());
    }

    [TestMethod]
    public void TestSort_Mixed()
    {
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "1", "one" } },
            new Dictionary<string, string> { { "a", "letter" } },
            new Dictionary<string, string> { { "A", "upper" } }
        };
        Lab2.Sort(list);

        // Проверка - '1' < 'A' < 'a'
        Assert.AreEqual("1", list[0].Keys.First());
        Assert.AreEqual("A", list[1].Keys.First());
        Assert.AreEqual("a", list[2].Keys.First());
    }

    [TestMethod]
    public void TestSort_SpecialCharacters()
    {
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "!", "excl" } },
            new Dictionary<string, string> { { "a", "letter" } },
            new Dictionary<string, string> { { "@", "at" } }
        };

        Lab2.Sort(list);

        Assert.AreEqual("!", list[0].Keys.First());
        Assert.AreEqual("@", list[1].Keys.First());
        Assert.AreEqual("a", list[2].Keys.First());
    }

    [TestMethod]
    public void TestSort_NumbersInKeys()
    {
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "10", "ten" } },
            new Dictionary<string, string> { { "2", "two" } },
            new Dictionary<string, string> { { "1", "one" } }
        };
        Lab2.Sort(list);

        // Проверка - строковое сравнение: "1" < "10" < "2"
        Assert.AreEqual("1", list[0].Keys.First());
        Assert.AreEqual("10", list[1].Keys.First());
        Assert.AreEqual("2", list[2].Keys.First());
    }
}
