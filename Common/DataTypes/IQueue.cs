using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTypes {
  public interface IQueue<T> {
    public int Size { get; }

    public bool IsEmpty { get; }

    public void Enqueue(T el);

    public T Dequeue();

    public T Front { get; }
  }
}
