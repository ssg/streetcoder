namespace Algorithms
{
    public class ContainsAlgorithms
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

        public static bool Contains(uint[] array, uint lookFor)
        {
            int start = 0;
            int end = array.Length - 1;
            while (start <= end)
            {
                int middle = start + ((end - start) / 2);
                uint value = array[middle];
                if (lookFor == value)
                {
                    return true;
                }
                if (lookFor > value)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }
            return false;
        }
    }
}