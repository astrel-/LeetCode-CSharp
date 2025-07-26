using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0012
{
    public string IntToRoman(int num)
    {
        var result = "";

        (var thousands, num) = int.DivRem(num, 1000);
        result += new string('M', thousands);
        (var hundreds, num) = int.DivRem(num, 100);
        if (hundreds == 9)
            result += "CM";
        else if (hundreds >= 5)
            result += "D" + new string('C', hundreds - 5);
        else if (hundreds == 4)
            result += "CD";
        else if (hundreds > 0)
            result += new string('C', hundreds);

        (var tens, num) = int.DivRem(num, 10);
        if (tens == 9)
            result += "XC";
        else if (tens >= 5)
            result += "L" + new string('X', tens - 5);
        else if (tens == 4)
            result += "XL";
        else if (tens > 0)
            result += new string('X', tens);

        var ones = num;
        if (ones == 9)
            result += "IX";
        else if (ones >= 5)
            result += "V" + new string('I', ones - 5);
        else if (ones == 4)
            result += "IV";
        else if (ones > 0)
            result += new string('I', ones);

        return result;
    }
}

public static class Problem0012Test
{
    public static IEnumerable<object[]> TestData()
    {
        yield return [3749, "MMMDCCXLIX"];
        yield return [58, "LVIII"];
        yield return [1994, "MCMXCIV"];
    }

    [TestCaseSource(nameof(TestData))]
    public static void Test(int input, string output)
    {
        var problem = new Problem0012();
        Assert.Equal(output, problem.IntToRoman(input));
    }
}