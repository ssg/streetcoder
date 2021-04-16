using System;
using System.Collections.Generic;
using System.Text;

class Locales
{
public bool IsGif(string fileName)
{
    return fileName.ToLower().EndsWith(".gif");
}
public bool IsGifFast(string fileName)
{
    return fileName.EndsWith(".gif", StringComparison.OrdinalIgnoreCase);
}
}
