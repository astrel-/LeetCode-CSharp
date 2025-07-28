using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0198
{
    public int Rob(int[] nums) 
    {
        var cache = new int?[nums.Length];
        return Math.Max(
            Rob(ref nums, 0, ref cache),
            Rob(ref nums, 1, ref cache));
    }

    private int Rob(ref int[] nums, int idx, ref int?[] cache)
    {
        if (idx >= nums.Length)
            return 0;
        
        if (cache[idx].HasValue)
            return cache[idx]!.Value;
        
        var robNext = idx >= nums.Length ? 0 : 
            nums[idx] + Rob(ref nums, idx + 2, ref cache);
        var robSkip = idx+1 >= nums.Length ? 0 : 
            nums[idx+1] + Rob(ref nums, idx + 3, ref cache);
        
        var res = Math.Max(robNext, robSkip);
        cache[idx] = res;

        return res;
    }
}

public static class Problem0198Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [(int []) [1,2,3,1], 4];
        yield return [(int []) [2,7,9,3,1], 12];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input, int output)
    {
        var problem = new Problem0198();
        Assert.Equal(output, problem.Rob(input));
    }
}