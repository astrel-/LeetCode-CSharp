using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0007
{
    public int Reverse(int x)
    {
        if (x == int.MinValue)
            return 0;
        var (sign, abs) = x >= 0 ? (1, x) : (-1, -x);
        var reverseChars = abs.ToString().Reverse().ToArray();
        var rev = int.TryParse(new string(reverseChars), out var res) ? res : 0;
        return sign * rev;
    }
}

public static class Problem0007Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [123, 321];
        yield return [-123, -321];
        yield return [120, 21];
        yield return [1534236469, 0];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int input, int output)
    {
        var problem = new Problem0007();
        Assert.Equal(output, problem.Reverse(input));
    }
}