using Common.DataTypes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Test.DataTypes {
  public class LoopDequeTest {
    [Test]
    public void DecreaseIndexTest() {
      var frontIndex = 3;
      var length = 5;

      Console.WriteLine(frontIndex);
      for (var i = 0; i < 20; i++) {
        frontIndex = (length + frontIndex - 1) % length;
        Console.WriteLine(frontIndex);
      }
    }

    [Test]
    public void IncreaseIndexTest() {
      var frontIndex = 3;
      var length = 5;

      Console.WriteLine(frontIndex);
      for (var i = 0; i < 20; i++) {
        frontIndex = (frontIndex + 1) % length;
        Console.WriteLine(frontIndex);
      }
    }

    [Test]
    public void FrontInTailOutTest() {
      var queue = new LoopDeque<int>();

      for (var i = 0; i < 30; i++) {
        queue.AddFront(i);
        Console.WriteLine(queue);
        if (i % 3 == 2) {
          Console.WriteLine("------------------------------------");
          queue.RemoveTail();
          Console.WriteLine(queue);
        }
      }
    }

    [Test]
    public void TailInFrontOutTest() {
      var queue = new LoopDeque<int>();

      for (var i = 0; i < 30; i++) {
        queue.AddTail(i);
        Console.WriteLine(queue);
        if (i % 3 == 2) {
          Console.WriteLine("------------------------------------");
          queue.RemoveFront();
          Console.WriteLine(queue);
        }
      }
    }
  }
}
