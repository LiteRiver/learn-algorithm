using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Common {
  public static class TestHelper {
    public static int[] GenSortedIntArray(int len) {
      if (len < 0) {
        throw new ArgumentException("Invalid array length");
      }

      var arr = new int[len];
      for (var i = 0; i < len; i++) {
        arr[i] = i;
      }

      return arr;
    }

    public static int[] GenUnsortedIntArray(int len) {
      if (len < 0) {
        throw new ArgumentException("Invalid array length");
      }

      var arr = new int[len];
      var rnd = new Random();
      for (var i = 0; i < len; i++) {
        arr[i] = rnd.Next();
      }

      return arr;
    }

    public static bool IsIntArraySorted(int[] arr) {
      if (arr == null) {
        throw new ArgumentNullException("arr");
      }

      for (var i = 1; i < arr.Length; i++) {
        if (arr[i - 1] > arr[i]) {
          return false;
        }
      }

      return true;
    }

    public static void BenchmarkSort(ISortable<int> sortable, int[] dataSizes) {
      foreach (var size in dataSizes) {
        var data = GenUnsortedIntArray(size);
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var ret = sortable.sort(data);
        stopwatch.Stop();

        if (!IsIntArraySorted(ret)) {
          throw new SystemException("Sort algorithm is not correctly implemented");
        }

        Console.WriteLine("data size: {0:n0}, elapsed: {1}", data.Length, FormatElapsed(stopwatch.Elapsed));
      }
    }

    public static string FormatElapsed(TimeSpan ts) {
      return string.Format(
        "{0:00}:{1:00}:{2:00}.{3:000}",
        ts.Hours, ts.Minutes, ts.Seconds,
        ts.Milliseconds);

    }
  }
}
