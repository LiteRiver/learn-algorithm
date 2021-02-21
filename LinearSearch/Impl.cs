using System;

namespace LinearSearch {
  class Impl<T> {
    public int search(T[] data, T target) {
      for (int i = 0; i < data.Length; i++) {
        if (data[i].Equals(target)) {
          return i;
        }
      }
      return -1;
    }
  }
}