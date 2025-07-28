using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0338
{
    public int[] CountBits(int n)
    {
        var res = new int[n + 1];
        res[0] = 0;
        for (var i = 1; i <= n; i++)
        {
            if (i % 2 == 1)
                res[i] = res[i / 2] + 1;
            else
                res[i] = res[i / 2];
        }
        return res;
    }
}

public static class Problem0338Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [0, (int []) [0]];
        yield return [1, (int []) [0,1]];
        yield return [2, (int []) [0,1,1]];
        yield return [5, (int []) [0,1,1,2,1,2]];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int input, int[] output)
    {
        var problem = new Problem0338();
        Assert.Equal(output, problem.CountBits(input));
    }
}