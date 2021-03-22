using System;

namespace Patterns {
  class Checksum {
    public static int CalculateChecksum(byte[] array) {
      int result = 0;
      for (int i = 0; i < array.Length; i++) {
        result += array[i];
      }
      return result;
    }

public static int CalculateChecksumParallel(byte[] array) {
  int r0 = 0, r1 = 0, r2 = 0, r3 = 0;
  int len = array.Length;
  int i = 0;
  for (; i < len - 4; i += 4) {
    r0 += array[i + 0];
    r1 += array[i + 1];
    r2 += array[i + 2];
    r3 += array[i + 3];
  }
  int remainingSum = 0;
  for (; i < len; i++) {
    remainingSum += i;
  }
  return r0 + r1 + r2 + r3 + remainingSum;
}
  }
}
