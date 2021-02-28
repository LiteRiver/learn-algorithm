namespace Common.DataTypes {
  public interface IDeque<T> {
    public int Size { get; }

    public bool IsEmpty { get; }

    public T Front { get; }

    public void AddFront(T el);

    public T RemoveFront();

    public T Tail { get; }

    public void AddTail(T el);

    public T RemoveTail();
  }
}
