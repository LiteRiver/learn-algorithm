using System;
using System.Linq;
using System.Diagnostics;
using Common;

namespace SelectionSort {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Benchmark with Impl<int>");
      TestHelper.BenchmarkSort(new Impl<int>(),new int[] { 10_000, 100_000 });
      Console.WriteLine("Benchmark with Impl2<int>");
      TestHelper.BenchmarkSort(new Impl2<int>(),new int[] { 10_000, 100_000 });
    }
  }
}
