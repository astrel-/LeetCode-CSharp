namespace LeetCode;

public class Problem0118
{
    public IList<IList<int>> Generate(int numRows) 
    {
        if  (numRows == 1)
            return new List<IList<int>> {new List<int> {1}};
        
        var prev = Generate(numRows - 1);
        var last = prev[^1];
        var curr = last.Zip(last.Skip(1)).Select(pair => pair.First + pair.Second).Prepend(1).Append(1).ToList();
        prev.Add(curr);
        return prev;
    }
}