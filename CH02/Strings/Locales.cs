using System;
using System.Collections.Generic;
using System.Text;

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
