using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0062
{
    public const int MODULO = 2_000_000_000;
    
    public int UniquePaths(int m, int n) 
    {
        var cache = new int[m, n];
        return UniquePaths(m-1, n-1, ref cache);
    }

    private int UniquePaths(int m, int n, ref int[,] cache)
    {
        if (m * n == 0)
            return 1;
        if (cache[m, n] != 0)
            return cache[m, n];
        
        int res;
        if (m == 0)
        {
            res = UniquePaths(0, n-1, ref cache) % MODULO;
            cache[m, n] = res;
            return res;
        }

        if (n == 0)
        {
            res = UniquePaths(m-1, 0, ref cache) % MODULO;
            cache[m, n] = res;
            return res;
        }
        
        res = UniquePaths(m - 1, n, ref cache) % MODULO + UniquePaths(m, n - 1, ref cache) % MODULO;
        cache[m, n] = res;
        return res;
    }
}

public static class Problem0062Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [2, 2, 2];
        yield return [3, 2, 3];
        yield return [3, 1, 1];
        yield return [1, 3, 1];
        yield return [4, 1, 1];
        yield return [1, 4, 1];
        yield return [3, 2, 3];
        yield return [3, 7, 28];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int input1, int input2, int output)
    {
        var problem = new Problem0062();
        Assert.Equal(output, problem.UniquePaths(input1, input2));
    }
}