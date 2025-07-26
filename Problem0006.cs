using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0006
{
    public string Convert(string s, int numRows)
    {
        if (numRows <= 1)
            return s;
        // if (s.Length <= numRows)
        //     return s;
        var res = new char[s.Length];
        var k = 2 * numRows - 2;
        var idx = 0;
        for (var row = 0; row < numRows; row++)
        {
            for (var col = 0; col < s.Length + k/2; col += k)
            {
                var undIdx = col - row;
                if (undIdx >= 0 && undIdx < s.Length)
                {
                    res[idx] = s[undIdx];
                    idx++;
                }

                undIdx = col + row;
                if (row > 0 && row < (numRows - 1) && undIdx >= 0 && undIdx < s.Length)
                {
                    res[idx] = s[undIdx];
                    idx++;
                }
            }
        }

        return new string(res);
    }
}

public static class Problem0006Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [("PAYPALISHIRING", 3), "PAHNAPLSIIGYIR"];
        yield return [("PAYPALISHIRING", 4), "PINALSIGYAHRPI"];
        yield return [("A", 1), "A"];
        yield return [("AB", 2), "AB"];
        yield return [("ABCD", 2), "ACBD"];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test((string InputString, int NumRows) input, string output)
    {
        var problem = new Problem0006();
        Assert.Equal(output, problem.Convert(input.InputString, input.NumRows));
    }
}