using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0238
{
    public int[] ProductExceptSelf(int[] nums) {
        var prefix = new int[nums.Length];
        var suffix = new int[nums.Length];

        var mul = 1;
        for (var i = 1; i < nums.Length; i++)
        {
            prefix[i] = mul *= nums[i - 1];
        }
        
        mul = 1;
        for (var i = nums.Length - 2; i >= 0; i--)
        {
            suffix[i] = mul *= nums[i+1];
        }
        
        var result = new int[nums.Length];
        result[0] = suffix[0];
        result[^1] = prefix[^1];
        for (var i = 1; i < nums.Length - 1; i++)
        {
            result[i] = prefix[i] * suffix[i];
        }
        
        return result;
    }
}

public static class Problem0238Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [(int []) [1,2,3,4], (int []) [24,12,8,6]];
        yield return [(int []) [-1,1,0,-3,3], (int []) [0,0,9,0,0]];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input, int[] output)
    {
        var problem = new Problem0238();
        Assert.Equal(output, problem.ProductExceptSelf(input));
    }
}