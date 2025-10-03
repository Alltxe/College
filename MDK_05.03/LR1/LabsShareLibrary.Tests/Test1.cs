using LabsShareLibrary;

namespace LabsShareLibrary.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestSort_EmptyList()
    {
        // Arrange
        var list = new List<Dictionary<string, string>>();

        // Act
        Lab2.Sort(list);

        // Assert
        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void TestSort_SingleElement()
    {
        // Arrange
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "key1", "value1" } }
        };

        // Act
        Lab2.Sort(list);

        // Assert
        Assert.AreEqual(1, list.Count);
        Assert.AreEqual("key1", list[0].Keys.First());
    }

    [TestMethod]
    public void TestSort_TwoElements_AlreadySorted()
    {
        // Arrange
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "a", "1" } },
            new Dictionary<string, string> { { "b", "2" } }
        };

        // Act
        Lab2.Sort(list);

        // Assert
        Assert.AreEqual("a", list[0].Keys.First());
        Assert.AreEqual("b", list[1].Keys.First());
    }

    [TestMethod]
    public void TestSort_TwoElements_ReverseSorted()
    {
        // Arrange
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "b", "2" } },
            new Dictionary<string, string> { { "a", "1" } }
        };

        // Act
        Lab2.Sort(list);

        // Assert
        Assert.AreEqual("a", list[0].Keys.First());
        Assert.AreEqual("b", list[1].Keys.First());
    }

    [TestMethod]
    public void TestSort_ThreeElements_AlreadySorted()
    {
        // Arrange
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "a", "1" } },
            new Dictionary<string, string> { { "b", "2" } },
            new Dictionary<string, string> { { "c", "3" } }
        };

        // Act
        Lab2.Sort(list);

        // Assert
        Assert.AreEqual("a", list[0].Keys.First());
        Assert.AreEqual("b", list[1].Keys.First());
        Assert.AreEqual("c", list[2].Keys.First());
    }

    [TestMethod]
    public void TestSort_ThreeElements_ReverseSorted()
    {
        // Arrange
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "c", "3" } },
            new Dictionary<string, string> { { "b", "2" } },
            new Dictionary<string, string> { { "a", "1" } }
        };

        // Act
        Lab2.Sort(list);

        // Assert
        Assert.AreEqual("a", list[0].Keys.First());
        Assert.AreEqual("b", list[1].Keys.First());
        Assert.AreEqual("c", list[2].Keys.First());
    }

    [TestMethod]
    public void TestSort_RandomOrder()
    {
        // Arrange
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "z", "3" } },
            new Dictionary<string, string> { { "a", "1" } },
            new Dictionary<string, string> { { "m", "2" } }
        };

        // Act
        Lab2.Sort(list);

        // Assert
        Assert.AreEqual("a", list[0].Keys.First());
        Assert.AreEqual("m", list[1].Keys.First());
        Assert.AreEqual("z", list[2].Keys.First());
    }

    [TestMethod]
    public void TestSort_Duplicates()
    {
        // Arrange
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "a", "1" } },
            new Dictionary<string, string> { { "a", "2" } },
            new Dictionary<string, string> { { "a", "3" } }
        };

        // Act
        Lab2.Sort(list);

        // Assert
        Assert.AreEqual("a", list[0].Keys.First());
        Assert.AreEqual("a", list[1].Keys.First());
        Assert.AreEqual("a", list[2].Keys.First());
    }

    [TestMethod]
    public void TestSort_NullKeys()
    {
        // Arrange - but Dictionary can't have null key, so skip or test empty
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string>(),
            new Dictionary<string, string> { { "a", "1" } }
        };

        // Act
        Lab2.Sort(list);

        // Assert - empty first
        Assert.AreEqual(0, list[0].Count);
        Assert.AreEqual("a", list[1].Keys.First());
    }

    [TestMethod]
    public void TestSort_EmptyKeys()
    {
        // Arrange
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "", "1" } },
            new Dictionary<string, string> { { "a", "2" } }
        };

        // Act
        Lab2.Sort(list);

        // Assert
        Assert.AreEqual("", list[0].Keys.First());
        Assert.AreEqual("a", list[1].Keys.First());
    }

    [TestMethod]
    public void TestSort_LargeList()
    {
        // Arrange
        var list = new List<Dictionary<string, string>>();
        for (int i = 10; i >= 1; i--)
        {
            list.Add(new Dictionary<string, string> { { $"key{i}", $"value{i}" } });
        }

        // Act
        Lab2.Sort(list);

        // Assert
        var expected = new[] { "key1", "key10", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], list[i].Keys.First());
        }
    }

    [TestMethod]
    public void TestSort_AllSame()
    {
        // Arrange
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "a", "1" } },
            new Dictionary<string, string> { { "a", "2" } },
            new Dictionary<string, string> { { "a", "3" } }
        };

        // Act
        Lab2.Sort(list);

        // Assert
        Assert.AreEqual("a", list[0].Keys.First());
        Assert.AreEqual("a", list[1].Keys.First());
        Assert.AreEqual("a", list[2].Keys.First());
    }

    [TestMethod]
    public void TestSort_Mixed()
    {
        // Arrange
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "1", "one" } },
            new Dictionary<string, string> { { "a", "letter" } },
            new Dictionary<string, string> { { "A", "upper" } }
        };

        // Act
        Lab2.Sort(list);

        // Assert - '1' < 'A' < 'a'
        Assert.AreEqual("1", list[0].Keys.First());
        Assert.AreEqual("A", list[1].Keys.First());
        Assert.AreEqual("a", list[2].Keys.First());
    }

    [TestMethod]
    public void TestSort_SpecialCharacters()
    {
        // Arrange
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "!", "excl" } },
            new Dictionary<string, string> { { "a", "letter" } },
            new Dictionary<string, string> { { "@", "at" } }
        };

        // Act
        Lab2.Sort(list);

        // Assert
        Assert.AreEqual("!", list[0].Keys.First());
        Assert.AreEqual("@", list[1].Keys.First());
        Assert.AreEqual("a", list[2].Keys.First());
    }

    [TestMethod]
    public void TestSort_NumbersInKeys()
    {
        // Arrange
        var list = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "10", "ten" } },
            new Dictionary<string, string> { { "2", "two" } },
            new Dictionary<string, string> { { "1", "one" } }
        };

        // Act
        Lab2.Sort(list);

        // Assert - string compare: "1" < "10" < "2"
        Assert.AreEqual("1", list[0].Keys.First());
        Assert.AreEqual("10", list[1].Keys.First());
        Assert.AreEqual("2", list[2].Keys.First());
    }
}
