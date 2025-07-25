using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0004
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var i1 = 0;
        var i2 = 0;
        var (mid1, rem) = int.DivRem(nums1.Length+nums2.Length, 2);
        var mid2 = rem == 1? mid1 : mid1 - 1;
        int? val1 = null;
        int? val2 = null;

        while (i1 < nums1.Length && i2 < nums2.Length)
        {
            if (nums1[i1] < nums2[i2])
            {
                if (i1 + i2 == mid2)
                {
                    val2 = nums1[i1];
                }
                if (i1 + i2 == mid1)
                {
                    val1 = nums1[i1];
                    break;
                }
                
                i1++;
            }
            else
            {
                if (i1 + i2 == mid2)
                {
                    val2 = nums2[i2];
                }
                if (i1 + i2 == mid1)
                {
                    val1 = nums2[i2];
                    break;
                }
                
                i2++;
            }
        }

        if (val2 is null && i1 + i2 <= mid2)
        {
            if (i1 == nums1.Length)
            {
                val2 = nums2[mid2 - i1];
            }
            else
            {
                val2 = nums1[mid2 - i2];
            }
        }
        if (val1 is null && i1 + i2 <= mid1)
        {
            if (i1 == nums1.Length)
            {
                val1 = nums2[mid1 - i1];
            }
            else
            {
                val1 = nums1[mid1 - i2];
            }
        }
        
        return (val1.Value + val2.Value) / 2.0f;
    }
}

public static class Problem0004Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [new[] {1}, Array.Empty<int>(), 1.0];
        yield return [new[] {1,3}, new[] {2}, 2.0];
        yield return [new[] {1,2}, new[] {3,4}, 2.5];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input1, int[] input2, double output)
    {
        var problem = new Problem0004();
        Assert.Equal(output, problem.FindMedianSortedArrays(input1, input2));
    }
}