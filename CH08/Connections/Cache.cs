using System.Threading;

namespace Connections {
  public class Cache {
    private static object instanceLock = new();
    private static Cache instance;
    public static Cache Instance {
      get {
        lock (instanceLock) {
          if (instance is null) {
            instance = new Cache();
          }
          return instance;
        }
      }
    }
    public static Cache Instance2 {
      get {
        if (instance is not null) {
          return instance;
        }
        lock (instanceLock) {
          if (instance is null) {
            instance = new Cache();
          }
          return instance;
        }
      }
    }

public static Cache Instance3 {
  get {
    return LazyInitializer.EnsureInitialized(ref instance);
  }
}
  }

}
