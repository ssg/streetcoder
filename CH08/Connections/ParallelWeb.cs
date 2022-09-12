using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Connections; 
public static class ParallelWeb {
public static async Task<Dictionary<Uri, string>> 
  DownloadAll(IEnumerable<Uri> uris) {
  var runningTasks = new Dictionary<Uri, Task<string>>();
  var client = new HttpClient();
  foreach (var uri in uris) {
    var task = client.GetStringAsync(uri);
    runningTasks.Add(uri, task);
  }
  await Task.WhenAll(runningTasks.Values);
  return runningTasks.ToDictionary(kp => kp.Key, 
    kp => kp.Value.Result);
}
}
