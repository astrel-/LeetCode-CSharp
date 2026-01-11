using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem1071
{
    public string Solve(string str1, string str2) {
        var n1 = str1.Length;
        var n2 = str2.Length;
        var m = int.Min(n1, n2);
        for(var i = m; i >0; i--)
        {
            var (k1, r1) = int.DivRem(n1, i);
            var (k2, r2) = int.DivRem(n2, i);
            if ((r1 != 0) || (r2 !=0 )) continue;

            var str = str1.Substring(0, i);

            var t1 = string.Concat(Enumerable.Repeat(str,k1));
            if (str1 != t1)
                continue;
            var t2 = string.Concat(Enumerable.Repeat(str,k2));
            if (str2 == t2)
                return str;
        }
        return "";
    }
}

public static class Problem1071Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return ["LEET", "CODE"];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(string str1, string str2)
    {
        var problem = new Problem1071();
        Assert.Equal("", problem.Solve(str1, str2));
    }
}