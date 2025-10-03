using System.Collections.Generic;
using System.Linq;

namespace LabsShareLibrary;

public class Lab2
{
    public static void Sort(List<Dictionary<string, string>> list)
    {
        if (list == null || list.Count <= 1) return;

        int n = list.Count;
        int gap = n / 2;
        while (gap > 0)
        {
            for (int i = gap; i < n; i++)
            {
                var temp = list[i];
                int j = i;
                while (j >= gap && Compare(list[j - gap], temp) > 0)
                {
                    list[j] = list[j - gap];
                    j -= gap;
                }
                list[j] = temp;
            }
            gap /= 2;
        }
    }

    private static int Compare(Dictionary<string, string> a, Dictionary<string, string> b)
    {
        var keyA = a.Keys.FirstOrDefault();
        var keyB = b.Keys.FirstOrDefault();
        if (keyA == null && keyB == null) return 0;
        if (keyA == null) return -1;
        if (keyB == null) return 1;
        return string.Compare(keyA, keyB, StringComparison.Ordinal);
    }
}