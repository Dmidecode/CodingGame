using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExemple
{
  class Program
  {
    public static async Task LaunchTask()
    {
      List<Task> liste = new List<Task>();
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine("LaunchTask: Avant le for");
      Console.ForegroundColor = ConsoleColor.White;
      for (int i = 0; i < 5; i += 1)
      {
        int test = i;
        Task newTask = Task.Run(() => 
        {
          Thread.Sleep(5000);
          Console.ForegroundColor = ConsoleColor.DarkCyan;
          Console.WriteLine($"LaunchTask [Task Parent { test }]: Thread.Sleep(5 secondes)");
          Console.ForegroundColor = ConsoleColor.White;
        } );
        newTask.ContinueWith(x => 
        {
          Thread.Sleep(3000);
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine($"LaunchTask [Task Continuation { test }]: Thread.Sleep(3 secondes)");
          Console.ForegroundColor = ConsoleColor.White;
        });
        liste.Add(newTask);
      }

      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine($"LaunchTask: Avant le Task.WaitAll(liste.ToArray())");
      Console.ForegroundColor = ConsoleColor.White;
      Task.WaitAll(liste.ToArray());
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine($"LaunchTask: Après le Task.WaitAll(liste.ToArray())");
      Console.ForegroundColor = ConsoleColor.White;
    }

    static void Main(string[] args)
    {
      Console.ForegroundColor = ConsoleColor.DarkMagenta;
      Console.WriteLine("Main: Avant la fonction d'appel au wait");
      Console.ForegroundColor = ConsoleColor.White;
      LaunchTask();
      Console.ForegroundColor = ConsoleColor.DarkMagenta;
      Console.WriteLine("Main: Après la fonction d'appel au wait");
      Console.ForegroundColor = ConsoleColor.White;

      while (true)
      {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("Dans la boucle ...");
        Console.ForegroundColor = ConsoleColor.White;
        Thread.Sleep(2000);
      }
    }
  }
}
