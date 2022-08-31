using System.Numerics;

namespace Patterns {
  public class BufferProcessor {
    public static void MultiplyEachSIMD(int[] buffer, int value) {
      if (!Vector.IsHardwareAccelerated) {
        MultiplyEachClassic(buffer, value);
        return;
      }

      int chunkSize = Vector<int>.Count;
      int n = 0;
      for (; n < buffer.Length - chunkSize; n += chunkSize) {
        var vector = new Vector<int>(buffer, n);
        vector *= value; // multiply all values in the vector at once
        vector.CopyTo(buffer, n); // replace the values
      }

      // process remaining bytes
      for (; n < buffer.Length; n++) {
        buffer[n] *= value;
      }
    }

    public static void MultiplyEachClassic(int[] buffer, int value) {
      for (int n = 0; n < buffer.Length; n++) {
        buffer[n] *= value;
      }
    }
  }
}
