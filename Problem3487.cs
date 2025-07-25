using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem3487
{
    public int MaxSum(int[] nums)
    {
        var trackMax = true;
        var max = -100;
        var sum = 0;
        var array = new bool[100];

        foreach (var num in nums)
        {
            if (trackMax)
            {
                if (num > 0)
                {
                    trackMax = false;
                    sum += num;
                    array[num-1] = true;
                }
                else
                    max =  Math.Max(max, num);
            }
            else
            {
                if (num > 0 && !array[num - 1])
                {
                    array[num-1] = true;
                    sum += num;
                }
            }
        }
        
        return trackMax ? max : sum;
    }
}

public static class Problem3487Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [new[] {1,2,3,4,5}, 15];
        yield return [new[] {1,1,0,1,1}, 1];
        yield return [new[] {1,2,-1,-2,1,0,-1}, 3];
        yield return [new[] {-1,-2,-1}, -1];
        yield return [new[] {-1,-2,0,-1}, 0];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input, int output)
    {
        var problem = new Problem3487();
        Assert.Equal(output, problem.MaxSum(input));
    }
}