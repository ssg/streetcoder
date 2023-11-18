using System;
using System.Linq;
using System.Threading.Tasks;

namespace Connections;
static class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Download all URLs given in command line in parallel");
        var uriArgs = args.Select(s => new Uri(s));
        // download everything in parallel
        var result = await ParallelWeb.DownloadAll(uriArgs);
        foreach (var pair in result)
        {
            Console.WriteLine($"{pair.Key,-40}: {pair.Value[..40]}...");
        }
    }
}
