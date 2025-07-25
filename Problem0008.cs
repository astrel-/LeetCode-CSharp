using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0008
{
    public int MyAtoi(string s)
    {
        var res = 0;
        var sign = 1;
        var numberNotStarted = true;
        var signNotDetermined = true;
        foreach (var c in s)
        {
            if (numberNotStarted)
            {
                if (c == ' ')
                {
                    continue;
                }

                numberNotStarted = false;
            }

            if (signNotDetermined)
            {
                if (c == '-')
                {
                    sign = -1;
                    signNotDetermined = false;
                    continue;
                }

                if (c == '+')
                {
                    signNotDetermined = false;
                    continue;
                }

                signNotDetermined = false;
            }

            if (c >= '0' && c <= '9')
            {
                if (sign > 0 && res > Int32.MaxValue / 10) return Int32.MaxValue;
                if (sign < 0 && sign * res < Int32.MinValue / 10) return Int32.MinValue;
                if (res > Int32.MaxValue / 10)
                    return sign > 0 ? Int32.MaxValue : Int32.MinValue;
                res *= 10;
                var diff = c - '0';
                if (sign > 0 && res > Int32.MaxValue - diff) return Int32.MaxValue;
                if (sign < 0 && sign * res < Int32.MinValue + diff) return Int32.MinValue;
                res += diff;
                continue;
            }

            break;
        }

        return res * sign;
    }
}

public static class Problem008Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return ["42", 42];
        yield return [" -042", -42];
        yield return ["1337c0d3", 1337];
        yield return ["0-1", 0];
        yield return ["words and 987", 0];
        yield return ["-91283472332", -2147483648];
        yield return ["2147483648", 2147483647];
        yield return ["-21474836482", -2147483648];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(string input, int output)
    {
        var problem = new Problem0008();
        Assert.Equal(output, problem.MyAtoi(input));
    }
}