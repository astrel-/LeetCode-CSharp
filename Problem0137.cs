namespace LeetCode;

public class Problem0137
{
    public int SingleNumber(int[] nums) {
        var ones = 0;
        var twos = 0;

        foreach (var num in nums) {
            ones ^= (num & ~twos);
            twos ^= (num & ~ones);
        }

        return ones;
    }
}