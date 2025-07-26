namespace LeetCode;

public class Problem0027
{
    public int RemoveElement(int[] nums, int val)
    {
        var idx = 0;
        foreach (var num in nums)
        {
            if (num != val)
            {
                nums[idx++] = num;
            }
        }
        return idx;    
    }
}