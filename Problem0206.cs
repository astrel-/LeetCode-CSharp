using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0206
{
    public ListNode? ReverseList(ListNode? head)
    {
        var vals = new List<int>();
        var node = head;
        while (node is not null)
        {
            vals.Add(node.val);
            node = node.next;
        }

        ListNode? result = null;
        foreach (var num in vals)
            result = new ListNode(num, result);
        return result;
    }
}

public static class Problem0206Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [(int [])[1,2,3,4,5]];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input)
    {
        var problem = new Problem0206();
        var output = input.Reverse().ToArray();
        Assert.Equal(output, problem.ReverseList(ListNode.FromArray(input)).Enumerate().ToArray());
    }
}