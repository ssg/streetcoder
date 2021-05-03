using System.Threading;

namespace Connections
{
  class UniqueIdGenerator
  {
    private int value;
    public int GetNextValue() => ++value;
  }
  class UniqueIdGeneratorAtomic
  {
    private int value;
    public int GetNextValue() => Interlocked.Increment(ref value);
  }
  class UniqueIdGeneratorLock
  {
    private int value;
    private object valueLock = new object();
    public int GetNextValue()
    {
      lock (valueLock)
      {
        return ++value;
      }
    }
  }
}
