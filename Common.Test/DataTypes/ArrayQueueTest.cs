using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Common.Test.DataTypes {
  public class ArrayQueueTest {
    [Test]
    public void EnqueueAndDequeue() {
      var queue = new ArrayQueue<int>();
      Assert.IsTrue(queue.IsEmpty);
      Assert.AreEqual(0, queue.Size);

      Console.WriteLine(queue);
      queue.Enqueue(3);
      Console.WriteLine(queue);
      queue.Enqueue(4);
      Console.WriteLine(queue);
      queue.Enqueue(1);
      Console.WriteLine(queue);

      Assert.IsFalse(queue.IsEmpty);
      Assert.AreEqual(3, queue.Size);
      Assert.AreEqual(3, queue.Front);

      Assert.AreEqual(3, queue.Dequeue());
      Assert.AreEqual(2, queue.Size);
      Assert.AreEqual(4, queue.Front);
      Console.WriteLine(queue);

      Assert.AreEqual(4, queue.Dequeue());
      Assert.AreEqual(1, queue.Size);
      Assert.AreEqual(1, queue.Front);
      Console.WriteLine(queue);
      
      Assert.AreEqual(1, queue.Dequeue());
      Assert.IsTrue(queue.IsEmpty);
      Assert.AreEqual(0, queue.Size);
      Console.WriteLine(queue);
      Assert.Catch<ArgumentOutOfRangeException>(() => queue.Dequeue());
      Assert.Catch<ArgumentOutOfRangeException>(() => { var f = queue.Front; });

      for(var i = 0; i < 20; i++) {
        queue.Enqueue(i);
      }
      Console.WriteLine(queue);

      Assert.GreaterOrEqual(queue.Capacity, 20);
    }
  }
}
