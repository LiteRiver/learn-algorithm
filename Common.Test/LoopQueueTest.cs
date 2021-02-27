using Common.DataTypes;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Common.Test {
  public class LoopQueueTest {
    [Test]
    public void EnqueueAndDequeue() {
      var queue = new LoopQueue<int>();
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

      for (var i = 0; i < 20; i++) {
        queue.Enqueue(i);
      }
      Console.WriteLine(queue);

      Assert.GreaterOrEqual(queue.Capacity, 20);
    }

    [Test]
    public void SimpleTest() {
      var queue = new LoopQueue<int>();

      for (var i = 0; i < 30; i++) {
        queue.Enqueue(i);
        Console.WriteLine(queue);
        if (i % 3 == 2) {
          queue.Dequeue();
          Console.WriteLine(queue);
        }
      }
    }

    [Test]
    public void QueuePerformanceTest() {
      var count = 100_000;
      QueueBatchOp(new ArrayQueue<int>(), count);
      QueueBatchOp(new LoopQueue<int>(), count);
    }

    private void QueueBatchOp(IQueue<int> queue, int count) {
      var rnd = new Random();
      var stopwatch = new Stopwatch();
      stopwatch.Start();
      for(var i = 0; i < count; i++) {
        queue.Enqueue(rnd.Next());
      }

      for (var i = 0; i < count; i++) {
        queue.Dequeue();
      }
      stopwatch.Stop();

      Console.WriteLine("Class: {0}, Count: {1}, Elapsed: {2}", queue.GetType().Name, count, TestHelper.FormatElapsed(stopwatch.Elapsed));
    }
  }
}
