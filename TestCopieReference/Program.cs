using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCopieReference
{
  class Program
  {
    static void Main(string[] args)
    {
      string s1 = "Interning";
      string s2 = new StringBuilder().Append("Inter").Append("ning").ToString();
      string s3 = String.Intern(s2);
      Console.WriteLine($"s1 == s2 {(Object)s1 == (Object)s2}");
      Console.WriteLine($"s2 == s3 {(Object)s2 == (Object)s3}");
      Console.WriteLine($"s1 == s3 {(Object)s1 == (Object)s3}");
    }
  }
}
