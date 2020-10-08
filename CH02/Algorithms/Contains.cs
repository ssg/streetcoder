namespace Algorithms
{
    public class Contains
    {
        public static bool Contains1(int[] array, int lookFor)
        {
            for (int n = 0; n < array.Length; n++)
            {
                if (array[n] == lookFor)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Contains2(int[] array, int lookFor)
        {
            if (lookFor < 1)
            {
                return false;
            }
            for (int n = 0; n < array.Length; n++)
            {
                if (array[n] == lookFor)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Contains3(uint[] array, uint lookFor)
        {
            for (int n = 0; n < array.Length; n++)
            {
                if (array[n] == lookFor)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Contains4(uint[] array, uint lookFor)
        {
            int start = 0;
            int end = array.Length - 1;
            while (start <= end)
            {
                int middle = (start + end) / 2;
                uint value = array[middle];
                if (lookFor == value)
                {
                    return true;
                }
                if (lookFor > value)
                {
                    start = middle + 1; // eliminate left half
                }
                else
                {
                    end = middle - 1; // eliminate right half
                }
            }
            return false;
        }
    }
}