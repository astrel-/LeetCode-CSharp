using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem077
{
    public IList<IList<int>> Combine(int n, int k, int start = 1)
    {
        if (k == 1)
        {
            var baseResult = new List<IList<int>>();
            for (var i = start; i <= n; i++)
                baseResult.Add(new List<int> {i});
            return baseResult;
        }

        var result = new List<IList<int>>();
        var range = Enumerable.Range(start, n - k + 1);
        foreach (var i in range)
        {
            foreach (var li in Combine(i, k - 1, n - i + start))
            {
                var res = new List<int> { i };
                res.AddRange(li);
                result.Add(res);
            }
        }

        return result;
    }
}

public static class Problem077Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [(1, 1), new int[][] {[1]}];
        yield return [(2, 1), new int[][] {[1], [2]}];
        yield return [(2, 2), new int[][] {[1,2]}];
        yield return [(4, 2), new int[][] {[1,2],[1,3],[1,4],[2,3],[2,4],[3,4]}];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test((int N, int K) input, int[][] output)
    {
        var problem = new Problem077();
        Assert.Equal(output, problem.Combine(input.N, input.K));
    }
}