using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0083
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head is null)
            return head!;
        var curr = head;
        var check = head.next;
        while (check is not null)
        {
            if (curr.val != check.val)
            {
                curr.next = check;
                curr = curr.next;
                check = curr.next;

            }
            else
            {
                check = check.next;
                if (check is null)
                {
                    curr.next = null!;
                    break;
                }
            }

        }
            
        return head;
    }
}

public static class Problem0083Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [new[] {1,1,2}, new[]{1,2}];
        yield return [new[] {1,1,2,2}, new[]{1,2}];
        yield return [new[] {1,1,2,2,2}, new[]{1,2}];
        yield return [new[] {1,1,2,3,3}, new[]{1,2,3}];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input, int[] output)
    {
        var problem = new Problem0083();
        Assert.Equal(output, problem.DeleteDuplicates(ListNode.FromArray(input)).Enumerate().ToArray());
    }
}