namespace LeetCode;

public class Problem0141
{
    public bool HasCycle(ListNode? head) {
        if (head?.next?.next is null)
            return false;
        var slow = head.next;
        var fast = head.next!.next;

        while(fast is not null)
        {
            if (slow == fast)
                return true;
            slow = slow!.next;
            if (fast.next?.next is not null)
                fast = fast.next!.next;
            else
                return false;
        }
        return false;
    }
}