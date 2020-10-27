using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
  static void Main(string[] args)
  {
    string MESSAGE = args[0];

    string res = string.Empty;
    string reverse = string.Empty;
    foreach (char m in MESSAGE)
    {
      int c = m;
      reverse = string.Empty;
      int countI = 0;
      while (countI < 7)
      {
        reverse += (c & 1) == 1 ? "1" : "0";
        c = c >> 1;
        countI += 1;
      }

      res += Reverse(reverse);
    }

    string unaire = string.Empty;
    for (int index = 0; index < res.Count(); )
    {
      index = CountBit(ref unaire, res, index, res[index] == '0' ? '0' : '1');
    }

    unaire = unaire.Remove(unaire.Count() - 1);
    Console.WriteLine(res);
    Console.WriteLine(unaire);
    Console.WriteLine("00 0 0 0 00 00 0 0 00 0 0 0");
    Console.ReadLine();
  }

  public static int CountBit(ref string unaire, string bits, int index, char bit)
  {
    unaire += bit == '1' ? "0 " : "00 ";
    while (index < bits.Count() && bits[index] == bit)
    {
      unaire += '0';
      index += 1;
    }

    unaire += ' ';

    return index;
  }

  public static string Reverse(string s)
  {
    char[] charArray = s.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
  }
}