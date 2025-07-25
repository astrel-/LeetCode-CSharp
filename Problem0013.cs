using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0013
{
    public int RomanToInt(string s)
    {
        var result = 0;

        // var idx1 = 0;
        var idx = 0;

        while (idx < s.Length)
        {
            var c =  s[idx];
            if (c == 'I')
            {
                if (idx + 1 < s.Length && s[idx + 1] == 'V')
                {
                    result += 4;
                    idx+=2;
                }
                else if (idx + 1 < s.Length && s[idx + 1] == 'X')
                {
                    result += 9;
                    idx+=2;
                }
                else
                {
                    result += 1;
                    idx++;
                }
                continue;
            }
            if (c == 'V')
            {
                result += 5;
                idx++;
                continue;
            }
            if (c == 'X')
            {
                if (idx + 1 < s.Length && s[idx + 1] == 'L')
                {
                    result += 40;
                    idx+=2;
                }
                else if (idx + 1 < s.Length && s[idx + 1] == 'C')
                {
                    result += 90;
                    idx+=2;
                }
                else
                {
                    result += 10;
                    idx++;
                }
                continue;
            }
            if (c == 'L')
            {
                result += 50;
                idx++;
                continue;
            }            
            if (c == 'C')
            {
                if (idx + 1 < s.Length && s[idx + 1] == 'D')
                {
                    result += 400;
                    idx+=2;
                }
                else if (idx + 1 < s.Length && s[idx + 1] == 'M')
                {
                    result += 900;
                    idx+=2;
                }
                else
                {
                    result += 100;
                    idx++;
                }
                continue;
            }
            if (c == 'D')
            {
                result += 500;
                idx++;
                continue;
            }
            if (c == 'M')
            {
                result += 1000;
                idx++;
            }
            
        }
        
        return result;
    }
}

public static class Problem013Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return ["III", 3];
        yield return ["IX", 9];
        yield return ["X", 10];
        yield return ["XI", 11];
        yield return ["LVIII", 58];
        yield return ["MCMXCIV", 1994];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(string input, int output)
    {
        var problem = new Problem0013();
        Assert.Equal(output, problem.RomanToInt(input));
    }
}