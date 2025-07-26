using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem1431
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        var result = new bool[candies.Length];
        var max = candies.Max();
        for (var i = 0; i < candies.Length; i++)
        {
            result[i] = candies[i] >= max - extraCandies;
        }
        return result;
    }
}

public static class Problem1431Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [(int[]) [1,2], 1, (bool[]) [true, true]];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input, int extra, IList<bool> output)
    {
        var problem = new Problem1431();
        Assert.Equal(output, problem.KidsWithCandies(input, extra));
    }
}