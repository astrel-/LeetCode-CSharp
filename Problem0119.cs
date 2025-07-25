namespace LeetCode;

public class Problem0119
{
    public IList<int> GetRow(int rowIndex) {
        var curr = new int[rowIndex+1];
        curr[0] = 1;
        curr[rowIndex] = 1;
        long num = 1;
        for (var i = 1; i < rowIndex; i++)
        {
            num *= rowIndex + 1 - i;
            num /= i;
            curr[i] = (int)num;
        }
            
        return curr.ToList();
    }
}