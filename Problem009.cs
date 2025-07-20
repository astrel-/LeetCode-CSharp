using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem009
{
    public bool IsPalindrome(int x) {
        if (x < 0) return false;
        if (x == 0) return true;

        var digits = new List<int>();
        var y = x;
        while (y > 0)
        {
            (y, var rem) = int.DivRem(y, 10);
            digits.Add(rem);
        }

        for (var i = 0; i <= digits.Count / 2; i++)
        {
            if (digits[i] != digits[digits.Count - 1 - i])
                return false;
        }
        return true;
    }
}

public static class Problem009Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [121, true];
        yield return [-121, false];
        yield return [10, false];
        yield return [0, true];
        yield return [6, true];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int input, bool output)
    {
        var problem = new Problem009();
        Assert.Equal(output, problem.IsPalindrome(input));
    }
}