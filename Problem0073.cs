using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0073
{
    public void SetZeroes(int[][] matrix)
    {
        var rows = new HashSet<int>();
        var cols = new HashSet<int>();
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 0)
                {
                    rows.Add(i);
                    cols.Add(j);
                }
            }
        }

        foreach (var row in rows)
        {
            for (var j = 0; j < matrix[row].Length; j++)
            {
                matrix[row][j] = 0;
            }
        }
        
        foreach (var col in cols)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                matrix[i][col] = 0;
            }
        }
    }
}

public static class Problem073Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [new int[][] {[1,1,1],[1,0,1],[1,1,1]}, new int[][] {[1,0,1],[0,0,0],[1,0,1]}];
        yield return [new int[][] {[0,1,2,0],[3,4,5,2],[1,3,1,5]}, new int[][] {[0,0,0,0],[0,4,5,0],[0,3,1,0]}];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[][] input, int[][] output)
    {
        var problem = new Problem0073();
        problem.SetZeroes(input);
        Assert.Equal(output, input);
    }
}