using System;

namespace Exceptions;
class Int
{
    public static int ParseDefault(string input,
      int defaultValue)
    {
        try
        {
            return int.Parse(input);
        }
        catch (FormatException)
        {
            return defaultValue;
        }
    }

    public static int ParseDefault2(string input,
      int defaultValue)
    {
        if (!int.TryParse(input, out int result))
        {
            return defaultValue;
        }
        return result;
    }
}
