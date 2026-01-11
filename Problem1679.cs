using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem1679
{
    public int Solve(int[] nums, int k) {
        var countMap = new Dictionary<int, int>();

        foreach(var num in nums)
        {
            if (countMap.ContainsKey(num))
                countMap[num]++;
            else
                countMap[num] = 1;
        }

        var res = 0;
        foreach(var kvp in countMap)
        {
            var (n, count) = kvp;
            if (2*n > k)
                continue;

            if (2 * n == k)
            {
                res += count/2;
                continue;                
            }

            if (countMap.TryGetValue(k-n, out var count2))
                res += Math.Min(count, count2);
        }        
        return res;
    }
}

public static class Problem1679Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return ["", ""];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(string input, string output)
    {
        var problem = new Problem1679();
    }
}