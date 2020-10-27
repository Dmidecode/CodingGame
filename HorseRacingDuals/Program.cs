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
    int N = int.Parse(args[0]);
    int min = int.MaxValue;
    List<int> powers = new List<int>();
    for (int i = 0; i < N; i++)
    {
      powers.Add(int.Parse(args[i + 1]));
      //powers = powers.OrderBy(x => x).ToList();
    }

    //foreach (int p in powers)
    //{
    //  int tmp = pi - p;
    //  if (tmp > 0 && tmp < min)
    //    min = tmp;
    //}

    powers = powers.OrderBy(x => x).ToList();
    for (int i = 1; i < powers.Count; i++)
    {
      min = Math.Min(min, powers[i] - powers[i - 1]);
    }
    // Write an action using Console.WriteLine()
    // To debug: Console.Error.WriteLine("Debug messages...");
    //Console.Error.WriteLine();

    Console.WriteLine(min);
    Console.ReadLine();
  }
}