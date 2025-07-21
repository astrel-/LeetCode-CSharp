using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem009
{
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;
        if (x == 0) return true;
        var reverse = 0;

        var y = x;
        while (x > 0)
        {
            (x, var rem) = int.DivRem(x, 10);
            reverse = reverse * 10 + rem;
        }
        return y == reverse;
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