using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0649
{
    public const string RADIANT = "Radiant";
    public const string DIRE = "Dire";
        
    public string PredictPartyVictory(string senate) 
    {
        var N = senate.Length;
        var r = new Queue<int>();
        var d = new Queue<int>();
        for (var idx = 0; idx < senate.Length; idx++)
        {
            if (senate[idx] == 'R')
                r.Enqueue(idx);
            else
                d.Enqueue(idx);
        }

        while (r.Count > 0 && d.Count > 0)
        {
            var rIdx = r.Dequeue();
            var dIdx = d.Dequeue();
            if (rIdx < dIdx)
                r.Enqueue(rIdx + N);
            else
                d.Enqueue(dIdx + N);
        }

        return r.Count > 0 ? RADIANT : DIRE;
    }
}

public static class Problem0649Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return ["RD", Problem0649.RADIANT];
        yield return ["RDD", Problem0649.DIRE];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(string input, string output)
    {
        var problem = new Problem0649();
        Assert.Equal(output, problem.PredictPartyVictory(input));
    }
}