using System;
using System.Linq;
using NUnit.Framework;
using Common;

namespace Common.Test {
  public class Tests {
    [SetUp]
    public void Setup() {
    }

    [Test]
    public void TestAdd() {
      var arr = new MyArray<int>();

      arr.Add(0, 101);
      arr.AddFirst(9);
      arr.AddLast(200);
      arr.Add(0, 222);
      arr.Add(1, 555);
      Console.WriteLine(arr);

      var ret = new int[] { 222, 555, 9, 101, 200 };

      Assert.AreEqual(arr.Size, ret.Length);
      for(var i = 0; i < ret.Length; i++) {
        Assert.AreEqual(ret[i], arr[i]);
      }
    }

    [Test]
    public void TestRemove() {
      var arr = new MyArray<int>();
      for (var i = 0; i < 10; i++) {
        arr.AddLast(i);
      }

      arr.Remove(5);
      Console.WriteLine(arr);
      var expectedArr = new int[] { 0, 1, 2, 3, 4, 6, 7, 8, 9 };
      Assert.AreEqual(expectedArr.Length, arr.Size);
      for(var i = 0; i < expectedArr.Length; i++) {
        Assert.AreEqual(arr[i], expectedArr[i]);
      }

      arr.RemoveAt(7);
      Console.WriteLine(arr);
      expectedArr = new int[] { 0, 1, 2, 3, 4, 6, 7, 9 };
      Assert.AreEqual(expectedArr.Length, arr.Size);
      for(var i = 0; i < expectedArr.Length; i++) {
        Assert.AreEqual(arr[i], expectedArr[i]);
      }
    }

    [Test]
    public void TestUpdate() {
      var arr = new MyArray<int>();
      arr.AddLast(1);
      arr.AddLast(2);
      arr.AddLast(3);
      Console.WriteLine(arr);

      arr[0] = 2;
      arr[1] = 3;
      arr[2] = 4;

      Console.WriteLine(arr);

      var expectedArr = new int[] { 2, 3, 4 };
      Assert.AreEqual(expectedArr.Length, arr.Size);
      for(var i = 0; i < expectedArr.Length; i++) {
        Assert.AreEqual(arr[i], expectedArr[i]);
      }
    }

    [Test]
    public void TestShrink() {
      var cap = 5;
      var arr = new MyArray<int>(cap);
      for (var i = 0; i < cap; i++) {
        arr.AddLast(i);
      }

      Assert.AreEqual(cap, arr.Capacity);

      arr.AddLast(100);
      Assert.Greater(arr.Capacity, cap);
      Console.WriteLine(arr);
      Console.WriteLine("Capacity = {0}", arr.Capacity);
    }
  }
}