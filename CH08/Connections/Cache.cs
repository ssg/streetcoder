using System.Threading;

namespace Connections;
public class Cache
{
    private static object instanceLock = new();
    private static Cache? instance;

    public static Cache Instance
    {
        get
        {
            lock (instanceLock)
            {
                return instance ??= new Cache();
            }
        }
    }
    public static Cache Instance2
    {
        get
        {
            if (instance is not null)
            {
                return instance;
            }
            lock (instanceLock)
            {                
                return instance ??= new Cache();
            }
        }
    }

    public static Cache Instance3 
        => LazyInitializer.EnsureInitialized(ref instance);
}

