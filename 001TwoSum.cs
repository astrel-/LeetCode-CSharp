using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class TwoSumProblem {

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


public static class TestTwoSum
{
    public sealed record Input(int[] Nums, int Target);
    public sealed record Output(int[] Indices);
    
    public static IEnumerable<(Input Input, Output Output)> TestData()
    {
        yield return (
            new Input([1,2], 3), 
            new Output([0,1]));
        
        yield return (
            new Input([2,7,11,15], 9), 
            new Output([0,1]));
        
        yield return (
            new Input([3,2,4], 6), 
            new Output([1,2]));
        
        yield return (
            new Input([3,3], 6), 
            new Output([0,1]));
        
    }
    
    [TestCaseSource(nameof(TestData))]
    public static void Test((Input input, Output output) data)
    {
        var (input, output) = data;
        var problem = new TwoSumProblem();
        Assert.Equal(problem.TwoSum(input.Nums, input.Target), output.Indices);
    }
}