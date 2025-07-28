using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0746
{
    public int MinCostClimbingStairs(int[] cost)
    {
        var cache = new int?[cost.Length];
        return MinCostClimbingStairs(ref cost, -1, ref cache);
    }

    private int MinCostClimbingStairs(ref int[] cost, int idx, ref int?[] cache)
    {
        if (idx >= cost.Length)
            return 0;
        if (idx == -1)
            return Math.Min( 
                MinCostClimbingStairs(ref cost, 0, ref cache),
                MinCostClimbingStairs(ref cost, 1, ref cache));
        if (idx >= 0 && cache[idx].HasValue)
            return cache[idx]!.Value;
        
        var res = cost[idx] + Math.Min( 
            MinCostClimbingStairs(ref cost, idx + 1, ref cache),
            MinCostClimbingStairs(ref cost, idx + 2, ref cache));
        cache[idx] = res;
        return res;
    }
}

public static class Problem0746Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [(int []) [10,15,20], 15];
        yield return [(int []) [1,100,1,1,1,100,1,1,100,1], 6];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input, int output)
    {
        var problem = new Problem0746();
        Assert.Equal(output, problem.MinCostClimbingStairs(input));
    }
}