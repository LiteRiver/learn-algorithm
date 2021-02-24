using System;
using System.Text;

namespace Common.DataTypes {
  public class Array<T> {
    private T[] data;

    public Array() : this(10) { }

    public Array(int capacity) {
      if (capacity < 1) {
        throw new ArgumentException("Invalid capacity");
      }

      data = new T[capacity];
      Size = 0;
    }

    public int Size { get; private set; }

    public int Capacity {
      get { return data.Length; }
    }

    public bool IsEmpty {
      get { return Size == 0; }
    }

    #region Find and Update

    public T First {
      get { return this[0]; }
    }

    public T Last {
      get { return this[Size - 1]; }
    }

    public int IndexOf(T el) {
      for (var i = 0; i < Size; i++) {
        if (data[i].Equals(el)) {
          return i;
        }
      }

      return -1;
    }

    public T this[int index] {
      get {
        if (index < 0 || index > Size - 1) {
          throw new ArgumentOutOfRangeException(nameof(index));
        }
        return data[index];
      }

      set {
        if (index < 0 || index > Size - 1) {
          throw new ArgumentOutOfRangeException(nameof(index));
        }

        data[index] = value;
      }
    }

    #endregion

    #region Add

    public void AddFirst(T el) {
      Add(0, el);
    }

    public void AddLast(T el) {
      Add(Size, el);
    }

    public void Add(int index, T el) {
      if (index < 0 || index > Size) {
        throw new ArgumentOutOfRangeException(nameof(index), "index range is [0, Size]");
      }

      Inflate();

      for (var i = Size - 1; i >= index; i--) {
        data[i + 1] = data[i];
      }

      data[index] = el;
      Size++;
    }

    #endregion

    #region Remove

    public bool Remove(T el) {
      var index = IndexOf(el);
      if (index == -1) {
        return false;
      } else {
        RemoveAt(index);
        return true;
      }
    }

    public T RemoveFirst() {
      return RemoveAt(0);
    }

    public T RemoveLast() {
      return RemoveAt(Size - 1);
    }

    public T RemoveAt(int index) {
      if (index < 0 || index > Size - 1) {
        throw new ArgumentOutOfRangeException(nameof(index));
      }

      var removed = data[index];
      for (var i = index + 1; i < Size; i++) {
        data[i - 1] = data[i];
      }

      Size--;
      Shrink();

      return removed;
    }

    #endregion

    public override string ToString() {
      var sb = new StringBuilder();
      sb.Append("Array [");

      for (var i = 0; i < Size; i++) {
        if (i == Size - 1) {
          sb.AppendFormat("{0}", data[i]);
        } else {
          sb.AppendFormat("{0}, ", data[i]);
        }
      }

      sb.Append("]");

      return sb.ToString();
    }

    private void Inflate() {
      if (Size == Capacity) {
        Resize(Capacity * 2);
      }
    }

    private void Shrink() {
      if (Size <= Capacity / 4 && Capacity / 2 != 0) {
        Resize(Capacity / 2);
      }
    }

    private void Resize(int newSize) {
      var newData = new T[newSize];

      for (var i = 0; i < Size; i++) {
        newData[i] = data[i];
      }

      data = newData;
    }
  }
}
