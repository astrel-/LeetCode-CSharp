using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem000
{
    public object Solve(object o)
    {
        return "";
    }
}

public static class Problem000Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return ["", ""];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(string input, string output)
    {
        var problem = new Problem000();
        Assert.Equal(output, problem.Solve(input));
    }
}