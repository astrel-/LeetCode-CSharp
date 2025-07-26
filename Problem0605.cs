using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0605
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        if (n < 1) 
            return true;
        if (flowerbed.Length < 1)
            return false;

        var idx = 0;
        while (idx < flowerbed.Length)
        {
            var prev = idx > 0 ? flowerbed[idx - 1] : 0;
            var curr = flowerbed[idx];
            var next = idx < flowerbed.Length - 1 ? flowerbed[idx+1] : 0;
            if (prev + curr + next == 0)
            {
                flowerbed[idx] = 1;
                if (--n == 0)
                    return true;
            }
            idx++;
        }

        return false;
    }
}

public static class Problem0605Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [(int []) [1,0,0,0,1], 1, true];
        yield return [(int []) [1,0,0,0,1], 2, false];
        yield return [(int []) [1,0,0,0,1], 5, false];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input, int n, bool output)
    {
        var problem = new Problem0605();
        Assert.Equal(output, problem.CanPlaceFlowers(input, n));
    }
}