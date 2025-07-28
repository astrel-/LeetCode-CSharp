using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0735
{
    public int[] AsteroidCollision(int[] asteroids)
    {
        var stack = new Stack<int>();
        foreach (var curr in asteroids)
        {
            if (stack.Count == 0)
            {
                stack.Push(curr);
                continue;
            }
            while (stack.TryPop(out var fromStack))
            {
                if (fromStack < 0 || curr > 0)
                {
                    stack.Push(fromStack);
                    stack.Push(curr);
                    break;
                }
                if (fromStack == -curr)
                    break;
                if (int.Abs(fromStack) > int.Abs(curr))
                {
                    stack.Push(fromStack); 
                    break;
                }
                if (stack.Count == 0)
                {
                    stack.Push(curr);
                    break;
                }
            }
        }
        return stack.Reverse().ToArray();
    }
}

public static class Problem0735Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [(int [])[5,10,-5], (int [])[5,10]];
        yield return [(int [])[8,-8],(int []) []];
        yield return [(int [])[10,2,-5],(int []) [10]];
        yield return [(int [])[-2,-1,1,2],(int []) [-2,-1,1,2]];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int[] input, int[] output)
    {
        var problem = new Problem0735();
        Assert.Equal(output, problem.AsteroidCollision(input));
    }
}