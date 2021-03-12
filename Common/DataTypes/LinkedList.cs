﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTypes {
  public class LinkedList<T> : IEnumerable<T> {
    private Node dummyHead;

    public int Size { get; private set; }

    public LinkedList() {
      dummyHead = new Node();
    }

    public void Insert(int index, T value) {
      if (index < 0 || index > Size) {
        throw new ArgumentOutOfRangeException(nameof(index), "index is our of range");
      }

      var prev = dummyHead;
      for (var i = 0; i < index; i++) {
        prev = prev.Next;
      }
      prev.Next = new Node(value, prev.Next);
      Size++;
    }

    public T RemoveAt(int index) {
      if (index < 0 || index > Size - 1) {
        throw new ArgumentOutOfRangeException(nameof(index), "index is our of range");
      }

      Node prev = dummyHead;
      for (var i = 0; i < index; i++) {
        prev = prev.Next;
      }

      var cur = prev.Next;
      prev.Next = cur.Next;
      cur.Next = null; // Set the next Node of current Node to null
      Size--;
      return cur.Value;
    }

    public void AddFirst(T value) {
      Insert(0, value);
    }

    public void AddLast(T value) {
      Insert(Size, value);
    }

    public T RemoveFirst() {
      return RemoveAt(0);
    }

    public T RemoveLast() {
      return RemoveAt(Size - 1);
    }

    public T First => this[0];

    public T Last => this[Size - 1];

    public bool IsEmpty => Size == 0;

    public bool Contains(T value) {
      foreach(var v in this) {
        if (v.Equals(value)) {
          return true;
        }
      }
      return false;
    }


    public T this[int index] {
      get {
        if (index < 0 || index > Size - 1) {
          throw new ArgumentOutOfRangeException(nameof(index), "index is out of range");
        }

        var cur = dummyHead.Next;
        for (var i = 0; i < index; i++) {
          cur = cur.Next;
        }

        return cur.Value;
      }

      set {
        if (index < 0 || index > Size - 1) {
          throw new ArgumentOutOfRangeException(nameof(index), "index is out of range");
        }

        var cur = dummyHead.Next;
        for (var i = 0; i < index; i++) {
          cur = cur.Next;
        }

        cur.Value = value;
      }
    }

    public override string ToString() {
      var sb = new StringBuilder();
      sb.Append("LinkedList: ");

      foreach (var v in this) {
        sb.AppendFormat("{0}->", v);
      }

      return sb.ToString();
    }

    public IEnumerator<T> GetEnumerator() {
      return new LinkedListEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return this.GetEnumerator();
    }

    private class Node {
      public Node(T value, Node next) {
        Value = value;
        Next = next;
      }

      public Node(T value) {
        Value = value;
      }

      public Node() { }

      public Node Next { get; set; }

      public T Value { get; set; }
    }

    private class LinkedListEnumerator : IEnumerator<T> {
      public LinkedList<T> LinkedList { get; set; }
      public T Current { get; set; }

      public Node CurrentNode { get; set; }

      public LinkedListEnumerator(LinkedList<T> linkedList) {
        LinkedList = linkedList;
        Current = default;
        CurrentNode = null;
      }

      object IEnumerator.Current => Current;

      public void Dispose() { }

      public bool MoveNext() {
        if (LinkedList.Size == 0) {
          return false;
        }

        if (CurrentNode == null) {
          CurrentNode = LinkedList.dummyHead.Next;
          Current = CurrentNode.Value;
          return true;
        }

        if (CurrentNode.Next == null) {
          return false;
        } else {
          CurrentNode = CurrentNode.Next;
          Current = CurrentNode.Value;
          return true;
        }
      }

      public void Reset() {
        CurrentNode = null;
      }
    }
  }
}
