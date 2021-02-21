using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LinearSearch {
  class Student : IEquatable<Student> {
    public Student(String name) {
      Name = name;
    }

    public String Name { get; }

    public bool Equals([AllowNull] Student other) {
      if (other == null) {
        return false;
      }

      return other.Name == Name;
    }

    public override bool Equals(object obj) {
      var other = obj as Student;
      if (other == null) {
        return false;
      }

      return other.Name == Name;
    }

    public override int GetHashCode() {
      return Name.GetHashCode();
    }
  }
}
