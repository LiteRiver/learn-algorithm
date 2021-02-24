using System;
using System.Text;

namespace Common.DataTypes {
  public class ArrayStack<T> : IStack<T> {
    private readonly Array<T> data;

    public ArrayStack(): this(10) { }

    public ArrayStack(int capacity) {
      data = new Array<T>(capacity);
    }

    public bool IsEmpty => data.IsEmpty;

    public int Size => data.Size;

    public int Capacity => data.Capacity;

    public T Peek() {
      return data.Last;
    }

    public T Pop() {
      return data.RemoveLast();
    }

    public void push(T el) {
      data.AddLast(el);
    }

    public override string ToString() {
      var sb = new StringBuilder();
      sb.Append("ArrayStack [");

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
  }
}
