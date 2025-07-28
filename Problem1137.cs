using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem1137
{
    private int[] _cache = new int[38];
    public int Tribonacci(int n) 
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        if (n == 2) return 1;
        if (_cache[n] != 0) return _cache[n];
        
        _cache[n] = Tribonacci(n - 1) + Tribonacci(n - 2) + Tribonacci(n - 3);
        return _cache[n];
    }
}

public static class Problem1137Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [4, 4];
        yield return [25, 1389537];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int input, int output)
    {
        var problem = new Problem1137();
        Assert.Equal(output, problem.Tribonacci(input));
    }
}