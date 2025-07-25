using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0001
{
    public int[] TwoSum(int[] nums, int target)
    {
        var hashTable = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (hashTable.TryGetValue(nums[i], out var idx))
                return [idx, i];
            hashTable[target - nums[i]] = i;
        }

        return [-1, -1];
    }
}

public static class Problem001Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return
        [
            (new[] { 1, 2 }, 3),
            new[] { 0, 1 }
        ];

        yield return
        [
            (new[] { 2, 7, 11, 15 }, 9),
            new[] { 0, 1 }
        ];

        yield return
        [
            (new[] { 3, 2, 4 }, 6),
            new[] { 1, 2 }
        ];

        yield return
        [
            (new[] { 3, 3 }, 6),
            new[] { 0, 1 }
        ];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test((int[] Nums, int Target) input, int[] output)
    {
        var (nums, target) = input;
        var problem = new Problem0001();
        Assert.Equal(output, problem.TwoSum(nums, target));
    }
}