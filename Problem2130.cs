using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem2130
{
    public int PairSum(ListNode? head)
    {
        var list = new List<int>();
        var tail = head;
        while (head is not null)
        {
            list.Add(head.val);
            head = head.next;
        }

        var sum = 0;
        for (var i = 0; i < list.Count/2; i++)
            sum = Math.Max(sum, list[i] + list[list.Count - i - 1]);
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