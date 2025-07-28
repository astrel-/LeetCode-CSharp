using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0746
{
    private int?[] _cache = new int?[1001];
    public int MinCostClimbingStairs(int[] cost, int idx = -1)
    {
        if (idx >= cost.Length)
            return 0;
        if (idx == -1)
            return Math.Min( 
                MinCostClimbingStairs(cost, 0),
                MinCostClimbingStairs(cost, 1));
        if (idx >= 0 && _cache[idx].HasValue)
            return _cache[idx]!.Value;
        
        var res = cost[idx] + Math.Min( 
            MinCostClimbingStairs(cost, idx + 1),
            MinCostClimbingStairs(cost, idx + 2));
        _cache[idx] = res;
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