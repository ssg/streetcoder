using System;

class Locales
{
    public bool isGif(string fileName)
    {
        return fileName.ToLower().EndsWith(".gif");
    }

    public bool isGifFast(string fileName)
    {
        return fileName.EndsWith(".gif", StringComparison.OrdinalIgnoreCase);
    }
}
