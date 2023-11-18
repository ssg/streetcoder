using BenchmarkDotNet.Attributes;

namespace Patterns;
public class Luhn
{
    public static bool CheckNaive(string number)
    {
        int sum = charToInt(number[^1]);
        if (sum < 0)
        {
            return false;
        }

        int len = number.Length;
        int parity = len % 2;

        for (int i = 0; i < len - 2; i++)
        {
            int digit = charToInt(number[i]);
            if (digit < 0)
            {
                return false;
            }
            if (i % 2 == parity)
            {
                digit *= 2;
            }
            if (digit > 9)
            {
                digit -= 9;
            }
            sum += digit;
        }
        return (sum % 10) == 0;
    }

    public unsafe static bool CheckUnsafe(string number)
    {
        int sum = charToInt(number[^1]);
        if (sum < 0)
        {
            return false;
        }

        int len = number.Length;
        int parity = len % 2;

        for (int i = 0; i < len - 2; i++)
        {
            int digit = charToInt(number[i]);
            if (digit < 0)
            {
                return false;
            }
            if (i % 2 == parity)
            {
                digit *= 2;
            }
            if (digit > 9)
            {
                digit -= 9;
            }
            sum += digit;
        }
        return (sum % 10) == 0;
    }

    private static int charToInt(char c)
    {
        int result = c - '0';
        if (result is < 0 or > 9)
        {
            return -1;
        }
        return result;
    }
}

public class LuhnBenchmark
{
    public string Number = "12345678901234567890";

    [Benchmark]
    public bool CheckNaive()
    {
        return Luhn.CheckNaive(Number);
    }

    [Benchmark]
    public bool CheckUnsafe()
    {
        return Luhn.CheckUnsafe(Number);
    }
}
