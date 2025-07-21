using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem075
{
    public void SortColors(int[] nums)
    {
        var redWhite = new[] {0,0};
        foreach (var num in nums)
        {
            if (num == 0)
                redWhite[0]++;
            else if (num == 1)
                redWhite[1]++;
        }

        int i;
        for (i = 0; i < redWhite[0]; i++)
            nums[i] = 0;
        for (i = redWhite[0]; i < redWhite[0] + redWhite[1]; i++)
            nums[i] = 1;
        for (i = redWhite[0] + redWhite[1]; i < nums.Length; i++)
            nums[i] = 2;
    }
}

public static class Problem075Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [new[] {2,0,2,1,1,0}, new[] {0,0,1,1,2,2}];
        yield return [new[] {2,0,1}, new[] {0,1,2}];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input, int[] output)
    {
        var problem = new Problem075();
        problem.SortColors(input);
        Assert.Equal(output, input);
    }
}