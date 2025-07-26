using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0014
{
    public string LongestCommonPrefix(string[] strs)
    {
        var result = "";
        var samePrefix = true;
        var idx = 0;
        while (samePrefix)
        {
            if (idx >= strs[0].Length)
                break;

            var c = strs[0][idx];
            for (var i = 1; i < strs.Length; i++)
            {
                var str = strs[i];
                if (idx >= str.Length || str[idx] != c)
                {
                    samePrefix = false;
                    break;
                }
            }

            if (samePrefix)
                result += c;
            idx++;
        }

        return result;
    }
}

public static class Problem0014Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [new[] { "flower", "flow", "flight" }, "fl"];
        yield return [new[] { "dog", "racecar", "car" }, ""];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(string[] input, string output)
    {
        var problem = new Problem0014();
        Assert.Equal(output, problem.LongestCommonPrefix(input));
    }
}