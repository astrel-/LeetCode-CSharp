using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0328
{
    public ListNode? OddEvenList(ListNode? head)
    {
        if (head is null)
            return null;
        
        var currOdd = head;
        if (head.next is null)
            return currOdd;
        
        var startEven = head.next;
        var currEven = head.next;
        var node = head.next.next;
        var isOdd = true;
        while (node is not null)
        {
            var next = node.next;
            if (isOdd)
            {
                currOdd.next = node;
                currOdd = currOdd.next;                
            }
            else
            {
                currEven.next = node;
                currEven = currEven.next;                
            }
            node = next;
            isOdd = !isOdd;
        }
        
        currOdd.next = startEven;
        currEven.next = null;
        return head;
    }
}

public static class Problem0328Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [(int[]) [1,2,3,4,5], (int[]) [1,3,5,2,4]];
        yield return [(int[]) [2,1,3,5,6,4,7], (int[]) [2,3,6,7,1,5,4]];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input, int[] output)
    {
        var problem = new Problem0328();
        Assert.Equal(output, problem.OddEvenList(ListNode.FromArray(input)).Enumerate().ToArray());
    }
}