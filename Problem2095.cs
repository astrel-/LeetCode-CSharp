using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem2095
{
    public ListNode DeleteMiddle(ListNode head)
    {
        var n = 0;
        var node = head;
        while (node != null)
        {
            node = node.next;
            n++;
        }

        if (n < 2)
            return null;
        node = head;
        for (var i = 0; i < n / 2 -1; i++)
        {
            node = node!.next;
        }
        node.next = node.next?.next;
        return head;
    }
}

public static class Problem2095Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [(int [])[1]];
        yield return [(int [])[2,1]];
        yield return [(int [])[1,3,4,7,1,2,6]];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input)
    {
        var problem = new Problem2095();
        
        var output = new int[input.Length-1];
        input[..(input.Length / 2)].CopyTo(output, 0);
        input[(input.Length / 2 + 1)..].CopyTo(output, input.Length / 2);
        
        Assert.Equal(output, problem.DeleteMiddle(ListNode.FromArray(input)).Enumerate().ToArray());
    }
}