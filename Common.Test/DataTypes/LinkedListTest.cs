using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Common.Test.DataTypes {
  public class LinkedListTest {
    [Test]
    public void InsertTest() {
      var list = new Common.DataTypes.LinkedList<int>();
      
      for (var i = 0; i < 10; i++) {
        list.AddFirst(i);
      }

      Console.WriteLine(list);

      var arr = new int[10];
      for (int i = 9, j = 0; i > -1; i--, j++) {
        arr[j] = i;
      }

      var index = 0;
      foreach(var i in list) {
        Assert.AreEqual(arr[index], i);
        index++;
      }

      list.RemoveFirst();
      Console.WriteLine(list);
      
      arr = new int[9];
      for (int i = 8, j = 0; i > -1; i--, j++) {
        arr[j] = i;
      }

      index = 0;
      foreach(var i in list) {
        Assert.AreEqual(arr[index], i);
        index++;
      }

      list.RemoveLast();
      Console.WriteLine(list);

      arr = new int[8];
      for (int i = 8, j = 0; i > 0; i--, j++) {
        arr[j] = i;
      }

      index = 0;
      foreach(var i in list) {
        Assert.AreEqual(arr[index], i);
        index++;
      }

      list.RemoveAt(1);
      Console.WriteLine(list);
      list.RemoveAt(5);
      Console.WriteLine(list);

      for (var i = 0; i < 5; i++) {
        list.RemoveFirst();
      }

      Console.WriteLine(list);

      for (var i = 2; i < 10; i++) {
        list.AddLast(i);
      }

      Console.WriteLine(list);

      arr = new int[9];
      for (int i = 1, j = 0; i < 10; i++, j++) {
        arr[j] = i;
      }

      index = 0;
      foreach(var i in list) {
        Assert.AreEqual(arr[index], i);
        index++;
      }

      list[0] = 99;
      arr[0] = 99;
      list[4] = 100;
      arr[4] = 100;
      list[list.Size - 1] = 999;
      arr[arr.Length - 1] = 999;
      Console.WriteLine(list);

      index = 0;
      foreach(var i in list) {
        Assert.AreEqual(arr[index], i);
        index++;
      }
    }
  }
}
