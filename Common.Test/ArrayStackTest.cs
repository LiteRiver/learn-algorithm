using System;
using NUnit.Framework;
using Common.DataTypes;

namespace Common.Test {
  public class ArrayStackTest {
    [Test]
    public void PushAndPop() {
      var stack = new ArrayStack<int>();

      stack.push(1);
      stack.push(3);
      stack.push(11);

      Console.WriteLine(stack);

      Assert.AreEqual(3, stack.Size);
      Assert.AreEqual(11, stack.Peek());

      Assert.AreEqual(11, stack.Pop());
      Assert.AreEqual(2, stack.Size);
      Assert.AreEqual(3, stack.Peek());
      Console.WriteLine(stack);

      Assert.AreEqual(3, stack.Pop());
      Assert.AreEqual(1, stack.Size);
      Assert.AreEqual(1, stack.Peek());
      Console.WriteLine(stack);

      Assert.AreEqual(1, stack.Pop());
      Assert.AreEqual(0, stack.Size);
      Assert.Catch<ArgumentOutOfRangeException>(() => stack.Peek());
      Assert.Catch<ArgumentOutOfRangeException>(() => stack.Pop());
      Console.WriteLine(stack);
    }
  }
}
