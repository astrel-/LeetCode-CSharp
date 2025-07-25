using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0120
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        var m = triangle.Count;
        var cache = new int?[m,m];
        
        return MinimumTotal(triangle, 0, 0, ref cache);
    }
    
    public int MinimumTotal(IList<IList<int>> triangle, int row, int index, ref int?[,] cache)
    {
        if (cache[row, index].HasValue)
            return cache[row, index]!.Value;
        var total = triangle[0][index];
        if (triangle.Count == 1)
        {
            cache[row, index] = total;
            return total;
        }
        var lowerTriangle = triangle.Skip(1).ToList();
        var left =  MinimumTotal(lowerTriangle, row+1, index, ref cache);
        var right = MinimumTotal(lowerTriangle, row+1, index+1, ref cache);
        var result = total + Math.Min(left, right);
        cache[row, index] = result;
        return result;
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