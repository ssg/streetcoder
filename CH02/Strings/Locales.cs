using System;
using System.Collections.Generic;
using System.Text;

class Locales
{
    public bool isGif(string fileName) => fileName.ToLower().EndsWith(".gif");
    public bool isGifFast(string fileName) => fileName.EndsWith(".gif", StringComparison.OrdinalIgnoreCase);
}
