using System;
using System.Text;

public class LargeNumber
{
    private readonly string number;

    public LargeNumber(string number)
    {
        this.number = number;
    }

    public static LargeNumber Add(LargeNumber a, LargeNumber b)
    {
        StringBuilder result = new StringBuilder();
        int cc = 0;

        string num1 = a.number.PadLeft(Math.Max(a.number.Length, b.number.Length), '0');
        string num2 = b.number.PadLeft(Math.Max(a.number.Length, b.number.Length), '0');

        for (int i = num1.Length - 1; i >= 0; i--)
        {
            int sum = (num1[i] - '0') + (num2[i] - '0') + cc;
            result.Insert(0, (char)('0' + sum % 10));
            cc = sum / 10;
        }

        if (cc != 0)
            result.Insert(0, (char)('0' + cc));

        return new LargeNumber(result.ToString());
    }

    public static LargeNumber Subtract(LargeNumber a, LargeNumber b)
    {
        if (string.Compare(a.number, b.number) < 0)
            throw new ArgumentException("");

        StringBuilder result = new StringBuilder();
        int bb= 0;

        string num1 = a.number.PadLeft(Math.Max(a.number.Length, b.number.Length), '0');
        string num2 = b.number.PadLeft(Math.Max(a.number.Length, b.number.Length), '0');

        for (int i = num1.Length - 1; i >= 0; i--)
        {
            int diff = (num1[i] - '0') - (num2[i] - '0') - bb;
            if (diff < 0)
            {
                diff += 10;
                bb = 1;
            }
            else
                bb = 0;

            result.Insert(0, (char)('0' + diff));
        }

        return new LargeNumber(result.ToString().TrimStart('0'));
    }

    public LargeNumber Multiply(LargeNumber other)
    {
        string num1 = this.number;
        string num2 = other.number;

        int len1 = num1.Length;
        int len2 = num2.Length;
        int[] result = new int[len1 + len2];

        for (int i = len1 - 1; i >= 0; i--)
        {
            int c = 0;
            int n1 = num1[i] - '0';

            for (int j = len2 - 1; j >= 0; j--)
            {
                int n2 = num2[j] - '0';
                int sum = n1 * n2 + result[i + j + 1] + c;
                c = sum / 10;
                result[i + j + 1] = sum % 10;
            }
            result[i] += c;
        }

        StringBuilder sb = new StringBuilder();
        foreach (int num in result)
        {
            sb.Append(num);
        }

        string resultString = sb.ToString().TrimStart('0');
        return new LargeNumber(resultString == "" ? "0" : resultString);
    }

    public override string ToString() => number;
}
