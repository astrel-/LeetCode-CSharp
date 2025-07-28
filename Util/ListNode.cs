namespace LeetCode;

// Definition for singly-linked list.
public class ListNode(int val = 0, ListNode? next = null)
{
    public int val = val;
    public ListNode? next = next;

    public static ListNode? FromArray(int[] inputs)
    {
        ListNode? result = null;
        foreach (var num in inputs.Reverse())
            result = new ListNode(num, result);
        return result;
    }
    
    public IEnumerable<int> Enumerate()
    {
        var node = this;
        while (node is not null)
        {
            yield return node.val;
            node = node.next;
        }
    }
}