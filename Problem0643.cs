using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0643
{
    public double Solve(int[] nums, int k) {
        var currSum = 0;
        for(var i=0; i<k; i++)
            currSum += nums[i];

        var maxSum = currSum;

        for(var i=k; i< nums.Length; i++)
        {
            currSum += nums[i];
            currSum -= nums[i-k];
            maxSum = Math.Max(maxSum, currSum);
        }
        
        return maxSum / 1.0 / k;
    }
}

public static class Problem0643Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [new[] {1,12,-5,-6,50,3}, 12.75];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input, double output)
    {
        var problem = new Problem0643();
        Assert.Equal(output, problem.Solve(input, 4));
    }
}