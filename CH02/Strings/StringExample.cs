using System;
using System.Text;

public class StringExample
{
    public static string JoinNames(string[] names)
    {
        string result = String.Empty;
        int lastIndex = names.Length - 1;
        for (int i = 0; i < lastIndex; i++)
        {
            result += names[i] + ", ";
        }
        result += names[lastIndex];

        return result;
    }

    public static string JoinNamesSB(string[] names)
    {
        var builder = new StringBuilder();
        int lastIndex = names.Length - 1;
        for (int i = 0; i < lastIndex; i++)
        {
            builder.Append(names[i]);
            builder.Append(", ");
        }
        builder.Append(names[lastIndex]);

        return builder.ToString();
    }

    public static string JoinNames2(string[] names) => String.Join(", ", names);
}
