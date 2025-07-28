using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem2390
{
    public string RemoveStars(string s) 
    {
        var res = new Stack<char>();
        foreach (var c in s)
        {
            if (c == '*')
                res.Pop();
            else
                res.Push(c);
        }
        return new string(res.Reverse().ToArray());
    }
}

public static class Problem2390Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return ["leet**cod*e", "lecoe"];
        yield return ["erase*****", ""];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(string input, string output)
    {
        var problem = new Problem2390();
        Assert.Equal(output, problem.RemoveStars(input));
    }
}