using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0120
{
    public int MinimumTotal(IList<IList<int>> triangle, int index=0)
    {
        var total = triangle[0][index];
        if (triangle.Count == 1)
            return total;
        var lowerTriangle = triangle.Skip(1).ToList();
        return total + Math.Min(
            MinimumTotal(lowerTriangle, index), 
            MinimumTotal(lowerTriangle, index + 1));
    }
}

public static class Problem0120Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return
        [
            new List<IList<int>>
            {
                (List<int>) [2],
                (List<int>) [3, 4],
                (List<int>) [6, 5, 7],
                (List<int>) [4, 1, 8, 3]
            },
            11
        ];
        yield return
        [
            new List<IList<int>>
            {
                (List<int>) [-10]
            },
            -10
        ];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(IList<IList<int>> input, int output)
    {
        var problem = new Problem0120();
        Assert.Equal(output, problem.MinimumTotal(input));
    }
}