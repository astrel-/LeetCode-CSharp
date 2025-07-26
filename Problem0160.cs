namespace LeetCode;

public class Problem0160
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {

        var a = headA;
        var b = headB;

        while (a!=b)
        {
            a = a is not null ? a.next : headB;
            b = b is not null ? b.next : headA;
        }

        return a;
    }
}