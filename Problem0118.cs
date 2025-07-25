namespace LeetCode;

public class Problem0118
{
    public IList<IList<int>> Generate(int numRows) 
    {
        if  (numRows == 1)
            return new List<IList<int>> {new List<int> {1}};
        
        var prev = Generate(numRows - 1);
        
        var curr = new int[numRows];
        curr[0] = 1;
        curr[numRows-1] = 1;
        var num = 1;
        for (var i = 1; i < numRows - 1; i++)
        {
            num *= numRows - i;
            num /= i;
            curr[i] = num;
        }
            
        prev.Add(curr.ToList());
        return prev;
    }
}