using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ResumeChapitre1.Enum;

namespace ResumeChapitre1.GestionMessageBox
{
  public static class FactoryMessage
  {
    public static string QuestionNom()
    {
      Console.WriteLine("Quel est ton nom ?");
      return Console.ReadLine();
    }

    public static void Bienvenue()
    {
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine($"Bienvenue { Program.Nom } dans le monster hunter du pauvre");
      Console.ForegroundColor = ConsoleColor.White;
    }

    public static TypeMap ChoixMap()
    {
      Console.Write("Choisis la zone de chasse: ");
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.Write($"[0] Forêt");
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write($" - ");
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write($"[1] Désert");
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write($" - ");
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write($"[2] Cimetière");
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write($" - ");
      Console.ForegroundColor = ConsoleColor.DarkMagenta;
      Console.Write($"[3] Terre des Anciens");
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine();
      return (TypeMap)System.Enum.Parse(typeof(TypeMap), Console.ReadLine());
    }

    public static void Demarrer()
    {
      Console.WriteLine("Appuyer sur entrée pour démarrer la partie");
      Console.ReadLine();
    }
  }
}
