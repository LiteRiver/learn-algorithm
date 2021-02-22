using System;
using Common;

namespace SelectionSort {
  public class Impl2<T> : ISortable<T> where T : IComparable<T> {
    public T[] sort(T[] data) {
      if (data == null) {
        throw new ArgumentNullException("data");
      }

      for (var i = data.Length - 1; i > -1; i--) {
        var maxIndex = i;
        for (var j = 0; j <= i; j++) { 
          if (data[j].CompareTo(data[maxIndex]) > 0) {
            maxIndex = j;
          }
        }
        var tmp = data[maxIndex];
        data[maxIndex] = data[i];
        data[i] = tmp;
      }

      return data;
    }
  }
}
