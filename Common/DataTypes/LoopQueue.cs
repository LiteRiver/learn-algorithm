using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTypes {
  public class LoopQueue<T> : IQueue<T> {
    private T[] data;

    private int frontIndex;

    private int tailIndex;

    public LoopQueue() : this(10) { }

    public LoopQueue(int capacity) {
      data = new T[capacity + 1];
    }

    public int Size {
      get;
      private set;
    }

    public bool IsEmpty => frontIndex == tailIndex;

    public int Capacity => data.Length - 1;

    public T Front {
      get {
        if (IsEmpty) {
          throw new ArgumentOutOfRangeException("frontIndex", "The queue is empty");
        }

        return data[frontIndex];
      }
    }

    public void Enqueue(T el) {
      Inflate();

      data[tailIndex] = el;
      tailIndex = (tailIndex + 1) % data.Length;
      Size++;
    }

    public T Dequeue() {
      if (IsEmpty) {
        throw new ArgumentOutOfRangeException("frontIndex", "The queue is empty");
      }
      var ret = data[frontIndex];
      data[frontIndex] = default;
      frontIndex = (frontIndex + 1) % data.Length;
      Size--;

      Shrink();
      return ret;
    }

    public override string ToString() {
      var sb = new StringBuilder();
      sb.AppendFormat("LoopQueue (s:{0}, c: {1}) <[", Size, Capacity);
      for (var i = frontIndex; i != tailIndex; i = (i + 1) % data.Length) {
        if ((i + 1) % data.Length == tailIndex) {
          sb.AppendFormat("{0}", data[i]);
        } else {
          sb.AppendFormat("{0}, ", data[i]);
        }
      }
      sb.Append("]<");

      return sb.ToString();
    }

    private void Inflate() {
      if ((tailIndex + 1) % data.Length == frontIndex) {
        Resize(Capacity * 2);
      }
    }

    private void Shrink() {
      if (Size == Capacity / 4 && Capacity / 2 != 0) {
        Resize(Capacity / 2);
      }
    }

    private void Resize(int newCapacity) {
      var newData = new T[newCapacity + 1];
      for (var i = 0; i < Size; i++) {
        newData[i] = data[(frontIndex + i) % data.Length];
      }
      data = newData;
      frontIndex = 0;
      tailIndex = Size;
    }
  }
}
