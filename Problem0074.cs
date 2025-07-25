using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0074
{
    public bool SearchMatrix(int[][] matrix, int target) 
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var left = (Row: 0, Col: 0);
        var right = (Row: m-1, Col: n-1);

        var lval = matrix[left.Row][left.Col];
        var rval = matrix[right.Row][right.Col];
        
        if (target <= lval)
            return target == lval;
        if (target >= rval)
            return target == rval;
        
        var leftIdx = left.Row * n + left.Col;
        var rightIdx = right.Row * n + right.Col;

        while (leftIdx < rightIdx)
        {
            var mid = int.DivRem((leftIdx + rightIdx)/2, n);
            var mval = matrix[mid.Quotient][mid.Remainder];
            if (mval == target)
                return true;
            if (mval < target)
            {
                if (left == mid)
                    return false;
                left = mid;
                lval = matrix[left.Row][left.Col];
                leftIdx = left.Row * n + left.Col;
            }
            else
            {
                if (right == mid)
                    return false;
                right = mid;
                rval = matrix[right.Row][right.Col];
                rightIdx = right.Row * n + right.Col;
            }
        }
        return false;
    }
}

public static class Problem074Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [(new int[][] {[1,3,5,7],[10,11,16,20],[23,30,34,60]}, 3), true];
        yield return [(new int[][] {[1,3,5,7],[10,11,16,20],[23,30,34,60]}, 13), false];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test((int[][] Matrix, int Target) input, bool output)
    {
        var problem = new Problem0074();
        Assert.Equal(output, problem.SearchMatrix(input.Matrix, input.Target));
    }
}