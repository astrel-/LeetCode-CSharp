using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem1768
{
    public string MergeAlternately(string word1, string word2) 
    {
        var result = new char [word1.Length + word2.Length];
        var idx1 = 0;
        var idx2 = 0;
        while (idx1 < word1.Length && idx2 < word2.Length)
        {
            result[idx1 + idx2] = word1[idx1];
            idx1++;
            result[idx1 + idx2] = word2[idx2];
            idx2++;
        }
        
        while (idx1 < word1.Length)
        {
            result[idx1 + idx2] = word1[idx1];
            idx1++;
        }
        
        while (idx2 < word2.Length)
        {
            result[idx1 + idx2] = word2[idx2];
            idx2++;
        }
        
        return new string(result);
    }
}

public static class Problem1768Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return ["abc", "pqr", "apbqcr"];
        yield return ["abc", "p", "apbc"];
        yield return ["abc", "", "abc"]; 
        yield return ["", "abc", "abc"]; 
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(string word1, string word2, string output)
    {
        var problem = new Problem1768();
        Assert.Equal(output, problem.MergeAlternately(word1, word2));
    }
}