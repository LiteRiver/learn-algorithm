using System;
using System.Diagnostics.CodeAnalysis;

namespace Common {
  public class Student : IEquatable<Student>, IComparable<Student> {

    public Student(String name) {
      if (String.IsNullOrWhiteSpace(name)) {
        throw new ArgumentNullException(name);
      }

      Name = name;
    }

    public String Name { get;  }

    public int CompareTo([AllowNull] Student other) {
      if (other == null) {
        throw new InvalidOperationException("null can not compare with Student");
      }

      return Name.CompareTo(other.Name);
    }

    public bool Equals([AllowNull] Student other) {
      if (other == null) {
        return false;
      }

      return Name == other.Name; 
    }

    public override bool Equals(object obj) {
      var other = obj as Student;
      var me = (IEquatable<Student>)this;

      return me.Equals(other);
    }

    public override int GetHashCode() {
      return Name.GetHashCode();
    }
  }
}
