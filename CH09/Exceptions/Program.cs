using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Exceptions; 
class Program {
private const string downloadFolder = "app2";
public static void Main(string[] args) {
  if (args.Length == 0) {
    Console.WriteLine("Usage: update <file_url> | -selfupdate");
    Environment.Exit(1);
  }

  string updatePath = Path.Combine(Path.GetTempPath(),
      downloadFolder);

  if (args[0] == "-selfupdate") {
    createUpdateFolder(updatePath);

    Console.WriteLine("Self updating...");
    if (!downloadFiles(updatePath, updateFiles)) {
      Console.WriteLine("Download failed, cleaning up");
      //...
    }
  }
}

private static void createUpdateFolder(string updatePath) {
  if (Directory.Exists(updatePath)) {
    Directory.Delete(updatePath);
  }
  Directory.CreateDirectory(updatePath);
}

private const string updateServerUriPrefix =
  "https://streetcoder.org/selfupdate/";

private static readonly string[] updateFiles =
  new[] { "Exceptions.exe", "Exceptions.app.config" };

private static bool downloadFiles(string directory,
  IEnumerable<string> files) {
  foreach (var filename in updateFiles) {
    string path = Path.Combine(directory, filename);
    var uri = new Uri(updateServerUriPrefix + filename);
    if (!downloadFile(uri, path)) {
      return false;
    }
  }
  return true;
}

private static bool downloadFile(Uri uri, string path) {
#pragma warning disable SYSLIB0014 // Type or member is obsolete
  // WebClient is old and soon to be obsoleted for making
  // HTTP requests. HttpClient should be preferred.
  // But it's simple enough for our example here.
  using var client = new WebClient();
  try {
    client.DownloadFile(uri, path);
    return true;
  }
  catch (WebException) {
    return false;
  }
}
#pragma warning restore SYSLIB0014 // Type or member is obsolete
}
