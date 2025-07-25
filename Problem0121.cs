using NUnit.Framework;
using NUnit.Framework.Constraints;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0121
{
    public int MaxProfit(int[] prices)
    {
        var buy = prices[0];
        var profit = 0;
        for (var i = 1; i < prices.Length; i++) {
            if (prices[i] < buy) {
                buy = prices[i];
            } else if (prices[i] - buy > profit) {
                profit = prices[i] - buy;
            }
        }
        return profit;
    }
}

public static class Problem0121Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [(int[]) [7,1,5,3,6,4], 5];
        yield return [(int[]) [7,6,4,3,1], 0];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input, int output)
    {
        var problem = new Problem0121();
        Assert.Equal(output, problem.MaxProfit(input));
    }
}