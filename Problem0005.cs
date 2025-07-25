using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0005
{
    public string LongestPalindrome(string s)
    {
        return "abc";
    }
}

public static class Problem005Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return ["babad", "bab"];
        yield return ["cbbd", "bb"];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(string input, string output)
    {
        var problem = new Problem0005();
        Assert.Equal(output, problem.LongestPalindrome(input));
    }
}