using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0011
{
    public int MaxArea(int[] height)
    {
        var left = 0;
        var right = height.Length - 1;
        var hLeft = height[0];
        var hRight = height[^1];
        var maxArea = Math.Min(hLeft, hRight) * (height.Length - 1);
        while (left < right)
        {
            if (hLeft > hRight)
            {
                right--;
                hRight = height[right];
            }
            else
            {
                left++;
                hLeft = height[left];
            }

            var currArea = Math.Min(hLeft, hRight) * (right - left);
            maxArea = Math.Max(maxArea, currArea);
        }

        return maxArea;
    }
}

public static class Problem011Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49];
        yield return [new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7, 1 }, 49];
        yield return [new[] { 1, 1 }, 1];
        yield return [new[] { 2, 1, 2 }, 4];
        yield return [new[] { 2, 1, 1, 2 }, 6];
        yield return [new[] { 2, 1, 2, 1 }, 4];
        yield return [new[] { 2, 2 }, 2];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input, int output)
    {
        var problem = new Problem0011();
        Assert.Equal(output, problem.MaxArea(input));
    }
}