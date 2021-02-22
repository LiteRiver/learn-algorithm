using System;
using Common;

namespace SelectionSort {
  public class Impl<T> : ISortable<T> where T : IComparable<T> {
    public T[] sort(T[] data) {
      if (data == null) {
        throw new ArgumentNullException("data");
      }

      for (var i = 0; i < data.Length - 1; i++) {
        var minIndex = i;

        for (var j = i; j < data.Length; j++) {
          if (data[j].CompareTo(data[minIndex]) < 0) {
            minIndex = j;
          }
        }

        var tmp = data[i];
        data[i] = data[minIndex];
        data[minIndex] = tmp;
      }

      return data;
    }
  }
}
