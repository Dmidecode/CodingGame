using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


class Solution
{

  const string alphabet = "abcdefghijklmnopqrstuvwxyz?";

  static void Main(string[] args)
  {
    List<string> argAlphabet = new List<string>
    {
      " #  ##   ## ##  ### ###  ## # # ###  ## # # #   # # ###  #  ##   #  ##   ## ### # # # # # # # # # # ### ### ",
      "# # # # #   # # #   #   #   # #  #    # # # #   ### # # # # # # # # # # #    #  # # # # # # # # # #   #   # ",
      "### ##  #   # # ##  ##  # # ###  #    # ##  #   ### # # # # ##  # # ##   #   #  # # # # ###  #   #   #   ## ",
      "# # # # #   # # #   #   # # # #  #  # # # # #   # # # # # # #    ## # #   #  #  # # # # ### # #  #  #       ",
      "# # ##   ## ##  ### #    ## # # ###  #  # # ### # # # #  #  #     # # # ##   #  ###  #  # # # #  #  ###  #  "
    };

    int L = int.Parse(args[0]);
    int H = int.Parse(args[1]);
    string T = args[2];

    string asciiAlphabet = string.Empty;
    int sizeRow = L * alphabet.Count();

    foreach (string argAl in argAlphabet)
    {
      int index = 0;
      foreach (char a in alphabet)
      {
        asciiAlphabet += argAl.Substring(L * index, L);
        index += 1;
      }
    }

    string res = string.Empty;
    for (int i = 0; i < H; i += 1)
    {
      foreach (char c in T.ToLower())
      {
        int index = alphabet.IndexOf(c);
        if (index < 0)
          index = 26;
        res += asciiAlphabet.Substring((sizeRow * i) + (index * L), L);
      }

      res += "\n";
    }

    Console.WriteLine(res);
  }
}