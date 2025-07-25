using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0003 {
    public int LengthOfLongestSubstring(string s)
    {
        var longest = 0;
        var hashTable = new Dictionary<char, int>();
        var a = 0;
        
        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (hashTable.TryGetValue(c, out var prevIdx))
            {
                longest = Math.Max(longest, i - a);
                for (var j = a; j <= prevIdx; j++)
                    hashTable.Remove(s[j]);
                a = prevIdx + 1;
            }
            hashTable.Add(c, i);
        }

        return Math.Max(longest, s.Length - a);
    }
}


public static class Problem003Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return ["abcabcbb", 3];
        yield return ["bbbbb", 1];
        yield return ["pwwkew", 3];
        yield return ["dvdf", 3];
        yield return ["", 0];
        yield return [" ", 1];
        yield return ["ckilbkd", 5];
        yield return ["tmmzuxt", 5];
    }
    
    [TestCaseSource(nameof(TestData))]
    public static void Test(string input, int output)
    {
        var problem = new Problem0003();
        Assert.Equal(output, problem.LengthOfLongestSubstring(input));
    }
}