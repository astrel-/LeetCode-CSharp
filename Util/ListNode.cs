namespace LeetCode;

// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }

    public static ListNode? FromArray(int[] inputs)
    {
        var node = new ListNode(inputs[^1], null!);
        foreach (var num in inputs.Reverse())
            node = new ListNode(num, node);
        return node;
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