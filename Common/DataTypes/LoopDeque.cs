using System;
using System.Text;

namespace Common.DataTypes {
  public class LoopDeque<T> : IDeque<T> {
    private T[] data;
    private int frontIndex;
    private int tailIndex;

    public LoopDeque() : this(10) { }

    public LoopDeque(int capacity) {
      data = new T[capacity];
      frontIndex = 0;
      tailIndex = 0;
    }

    public int Size {
      get;
      private set;
    }

    public bool IsEmpty => Size == 0;

    public int Capacity => data.Length;

    public T Front {
      get {
        if (IsEmpty) {
          throw new InvalidOperationException("The deque is empty");
        }

        return data[frontIndex];
      }
    }

    public T Tail {
      get {
        if (IsEmpty) {
          throw new InvalidOperationException("The deque is empty");
        }

        return data[tailIndex];
      }
    }

    public void AddFront(T el) {
      Inflate();

      frontIndex = frontIndex == 0 ? data.Length - 1 : frontIndex - 1;
      data[frontIndex] = el;
      Size++;
    }

    public void AddTail(T el) {
      Inflate();

      data[tailIndex] = el;
      tailIndex = (tailIndex + 1) % data.Length;
      Size++;
    }

    public T RemoveFront() {
      if (IsEmpty) {
        throw new InvalidOperationException("The deque is empty");
      }

      var ret = data[frontIndex];
      data[frontIndex] = default;
      frontIndex = (frontIndex + 1) % data.Length;
      Size--;
      Shrink();

      return ret;
    }

    public T RemoveTail() {
      if (IsEmpty) {
        throw new InvalidOperationException("The deque is empty");
      }

      tailIndex = tailIndex == 0 ? data.Length - 1 : tailIndex - 1;
      var ret = data[tailIndex];
      data[tailIndex] = default;
      Size--;
      Shrink();

      return ret;
    }

    public override string ToString() {
      var sb = new StringBuilder();
      sb.AppendFormat("LoopQueue (s:{0}, c: {1}) <>[", Size, Capacity);
      for (var i = 0; i < Size; i++) {
        if ((i + 1) == Size) {
          sb.AppendFormat("{0}", data[(i + frontIndex) % Capacity]);
        } else {
          sb.AppendFormat("{0}, ", data[(i + frontIndex) % Capacity]);
        }
      }
      sb.Append("]<>");

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

    private void Resize(int newCapacity) {
      var newData = new T[newCapacity];

      for (var i = 0; i < Size; i++) {
        newData[i] = data[(frontIndex + i) % data.Length];
      }

      data = newData;
      frontIndex = 0;
      tailIndex = Size;
    }
  }
}
