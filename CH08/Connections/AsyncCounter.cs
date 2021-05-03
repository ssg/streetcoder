using System;
using System.Threading;
using System.Threading.Tasks;

namespace Connections {
  public sealed class AsyncCounter: IDisposable {
    private int value;
    private SemaphoreSlim semaphore 
      = new(initialCount: 0, maxCount: 1);

    public void Dispose() {
      semaphore?.Dispose();
      semaphore = null;
    }

    public async Task<int> GetNextValue() {
      int returnValue;
      await semaphore.WaitAsync();
      returnValue = ++value;
      semaphore.Release();
      return returnValue;
    }
  }
}
