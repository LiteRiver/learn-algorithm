using System;

namespace Common {
  public interface ISortable<T> where T: IComparable<T> {
    public T[] sort(T[] data);
  }
}
