using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem2130
{
    public int PairSum(ListNode? head)
    {
        var slow = head;
        var fast = head;
        while (fast?.next is not null)
        {
            slow = slow!.next;
            fast = fast.next.next;
        }

        ListNode? prev = null;
        while (slow is not null)
        {
            var next = slow.next;
            slow.next = prev;
            prev = slow;
            slow = next;
        }

        var sum = 0;
        while (head is not null && prev is not null)
        {
            sum = int.Max(sum, head.val + prev.val);            
            head = head.next;
            prev = prev.next;
        }

        return sum;
    }
}

public static class Problem2130Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [(int [])[5,4,2,1], 6];
        yield return [(int [])[4,2,2,3], 7];
        yield return [(int [])[1,100000], 100001];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input, int output)
    {
        var problem = new Problem2130();
        Assert.Equal(output, problem.PairSum(ListNode.FromArray(input)));
    }
}