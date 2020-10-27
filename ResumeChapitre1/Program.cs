using ResumeChapitre1.Maps;
using ResumeChapitre1.GestionMessageBox;
using ResumeChapitre1.Sons;
using System;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using static ResumeChapitre1.Enum;
using ResumeChapitre1.Entite;

namespace ResumeChapitre1
{
  public static class ConsoleSpinner
  {
    static int counter;

    public static void Turn()
    {
      counter++;
      switch (counter % 4)
      {
        case 0: Console.Write(" /"); counter = 0; break;
        case 1: Console.Write(" -"); break;
        case 2: Console.Write(" \\"); break;
        case 3: Console.Write(" |"); break;
      }
      Thread.Sleep(100);
      Console.SetCursorPosition(Math.Max(Console.CursorLeft, 2) - 2, Console.CursorTop);
    }
  }

  class Program
  {
    public static string Nom { get; set; }

    static void Main(string[] args)
    {
      #region Initialisation
      // On charge tous les sons au début du programme
      FactorySon.Chargement();

      Nom = FactoryMessage.QuestionNom();
      FactoryMessage.Bienvenue();
      #endregion

      #region Démarrage map
      IMap mission = FactoryMap.Generate(FactoryMessage.ChoixMap());
      mission.DumpMonstres();

      FactoryMessage.Demarrer();
      FactoryMap.StartMap(mission);
      FactoryMap.CheckMap(mission);
      FactoryMap.StopMap(mission);
      #endregion

      Console.ReadLine();
    }
  }
}
