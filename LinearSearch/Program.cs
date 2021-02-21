using System;

namespace LinearSearch {
  class Program {
    static void Main(string[] args) {
      var impl = new Impl<int>();
      var data = new int[] { 24, 18, 12, 9, 16, 66, 32, 4 };
      var ret = impl.search(data, 16);
      Console.WriteLine(ret);

      var implS = new Impl<Student>();
      var students = new Student[] {
        new Student("CLIVE"),
        new Student("YQ"),
        new Student("ZXC")
      };
      var found = implS.search(students, new Student("YQ"));
      Console.WriteLine(found);
    }
  }
}
