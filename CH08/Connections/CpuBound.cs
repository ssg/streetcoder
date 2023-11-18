using System;
using System.Threading;
using System.Threading.Tasks;

namespace Connections;
class CpuBound
{
    public async Task LongWork()
    {
        await Task.Run(() => computeMeaningOfLifeUniverseAndEverything());
    }

    private ManualResetEvent completionEvent = new(initialState: false);
    public void LongWorkThread()
    {
        ThreadPool.QueueUserWorkItem(state =>
        {
            computeMeaningOfLifeUniverseAndEverything();
            completionEvent.Set();
        });
        completionEvent.WaitOne();
    }

    private void computeMeaningOfLifeUniverseAndEverything()
    {
        throw new NotImplementedException();
    }
}
