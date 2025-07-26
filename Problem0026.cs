namespace LeetCode;

public class Problem0026
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
            return 0;
        var idx = 1;
        var curr = nums[0];
        foreach (var num in nums.Skip(1))
        {
            if (num != curr)
            {
                curr = num;
                nums[idx++] = curr;
            }
        }
        return idx;
    }
}