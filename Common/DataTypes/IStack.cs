using System;

namespace Common.DataTypes {
  public interface IStack<T> {
    public void push(T el);

    public T Pop();

    public T Peek();

    public bool IsEmpty { get; }

    public int Size { get; }
  }
}
