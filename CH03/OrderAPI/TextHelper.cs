using System;

public static class TextHelper
{
    public static string Capitalize(string text)
    {
        if (text.Length < 2)
        {
            return text;
        }

        return Char.ToUpper(text[0]) + text.Substring(1).ToLower();
    }

    public static string Capitalize(string text,
      bool everyWord = false)
    {
        if (text.Length < 2)
        {
            return text.ToUpper();
        }
        if (!everyWord)
        {
            return Char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }
        string[] words = text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = Capitalize(words[i]);
        }

        return String.Join(" ", words);
    }

    public static string Capitalize(string text,
      bool everyWord = false, bool filename = false)
    {
        if (text.Length < 2)
        {
            return text.ToUpper();
        }
        if (!everyWord)
        {
            if (filename)
            {
                return Char.ToUpperInvariant(text[0])
                  + text.Substring(1).ToLowerInvariant();
            }
            return Char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }
        string[] words = text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = Capitalize(words[i]);
        }
        string separator = " ";
        if (filename)
        {
            separator = "_";
        }

        return String.Join(separator, words);
    }

    public static string CapitalizeFirstLetter(string text)
    {
        if (text.Length < 2)
        {
            return text.ToUpper();
        }

        return Char.ToUpper(text[0]) + text.Substring(1).ToLower();
    }

    public static string CapitalizeEveryWord(string text)
    {
        var words = text.Split(' ');
        for (int n = 0; n < words.Length; n++)
        {
            words[n] = CapitalizeFirstLetter(words[n]);
        }

        return String.Join(" ", words);
    }

    public static string FormatFilename(string filename)
    {
        var words = filename.Split(' ');
        for (int n = 0; n < words.Length; n++)
        {
            string word = words[n];
            if (word.Length < 2)
            {
                words[n] = word.ToUpperInvariant();
            }
            else
            {
                words[n] = Char.ToUpperInvariant(word[0]) +
                  word.Substring(1).ToLowerInvariant();
            }
        }

        return String.Join("_", words);
    }
}