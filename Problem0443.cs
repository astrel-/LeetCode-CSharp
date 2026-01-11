using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0443
{
    public int Solve(char[] chars) {
        var currPos = 1;
        var currChar = chars[0];
        var count = 1;
        

        for (var idx = 1; idx < chars.Length; idx++)
        {
            if (currChar == chars[idx])
            {
                count++;
                continue;
            }
            else
            {
                if (count != 1)
                {
                    var countStr = $"{count}";
                    foreach(var c in countStr)
                    {
                        chars[currPos++] = c;
                    }
                }
                currChar = chars[idx];
                count = 1;
                chars[currPos++] = currChar;
            }
        }

        if (count != 1) 
        {
            var countStr = $"{count}";
            foreach(var c in countStr)
            {
                chars[currPos++] = c;
            }
        }

        return currPos;
    }
}

public static class Problem0443Test
{
    [TestCase]
    public static void Test()
    {
        var chars = new[] {'a', 'a', 'b', 'b', 'c', 'c', 'c'};
        var chars2 = new[] { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b'};
        var problem = new Problem0443();
        problem.Solve(chars2);
    }
}