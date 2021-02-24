using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTypes {
  public class ArrayQueue<T> : IQueue<T> {
    private readonly Array<T> data;

    public ArrayQueue() : this(10) { }

    public ArrayQueue(int capacity) {
      data = new Array<T>(capacity);
    }

    public int Capacity => data.Capacity;

    public int Size => data.Size;

    public bool IsEmpty => data.IsEmpty;

    public T Front => data.First;

    public T Dequeue() {
      return data.RemoveAt(0);
    }

    public void Enqueue(T el) {
      data.AddLast(el);
    }

    public override string ToString() {
      var sb = new StringBuilder();
      sb.AppendFormat("ArrayQueue(s:{0}, c: {1}) <[", Size, Capacity);
      for (var i = 0; i < data.Size; i++) {
        if (i == data.Size - 1) {
          sb.AppendFormat("{0}", data[i]);
        } else {
          sb.AppendFormat("{0}, ", data[i]);
        }
      }
      sb.Append("]<");

      return sb.ToString();
    }
  }
}
