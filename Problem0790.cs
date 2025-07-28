using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0790
{

    public const int MODULO = 1_000_000_007;
    public int NumTilings(int n)
    {
        var cache = new int[n+1];
        return NumTilings(n, ref cache);
    }
    
    public int NumTilings(int n, ref int[] cache)
    {
        if (n == 0)
            return 1;
        if (n == 1)
            return 1;
        if (n == 2)
            return 2;
        
        if (cache[n] != 0)
            return cache[n];
        
        var res = 0;
        if (n >= 1)
        {
            res += NumTilings(n - 1, ref cache) % MODULO;
            res %= MODULO;
        }

        if (n >= 2)
        {
            res +=  NumTilings(n - 2, ref cache) % MODULO;
            res %= MODULO;
        }
        for (var j = 3; j <= n; j++)
        {
            res += 2 * NumTilings(n-j, ref cache) % MODULO;
            res %= MODULO;
        }
            
        res %= MODULO;
        cache[n] = res;
        return res;
    }
}

public static class Problem0790Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [1, 1];
        yield return [2, 2];
        yield return [3, 5];
        yield return [4, 11];
        yield return [30, 312342182];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int input, int output)
    {
        var problem = new Problem0790();
        Assert.Equal(output, problem.NumTilings(input));
    }
}