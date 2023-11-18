using System.Threading;

namespace Patterns;
class Boolean
{
    public static bool CheckIfThingsFail(int x)
    {
        if (VerySlowCheck() && x > 5)
        {
            return true;
        }
        return false;
    }

    protected static bool VerySlowCheck()
    {
        Thread.Sleep(1000);
        return true;
    }
}
