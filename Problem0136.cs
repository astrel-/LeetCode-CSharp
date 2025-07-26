namespace LeetCode;

public class Problem0136
{
    public int SingleNumber(int[] nums) {
        int result = 0;
        foreach (var num in nums)
            result ^= num;
        return result;
    }
}