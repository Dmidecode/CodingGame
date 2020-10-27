using ResumeChapitre1.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResumeChapitre1.Entite
{
  public class Player : Entite
  {
    DateTime action;
    public int SubZoneDestination = 0;

    public Player()
    {
      this.Attaque = 5;
      this.Pdv = 100;
      this.SubZone = 0;
    }

    public Enum.EtatPlayer Etat;

    public void Play(IMap map)
    {
      switch (Etat)
      {
        case Enum.EtatPlayer.Attaque:
          break;
        case Enum.EtatPlayer.Mouvement:
          if (this.CheckDestination())
          {
            this.Arrivee();
          }
          else
          {
            string trajetRestant = Math.Round(10 - new TimeSpan(DateTime.Now.Ticks - action.Ticks).TotalSeconds).ToString("00");
            Console.Write("\r");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"Déplacement vers la SubZone { this.SubZoneDestination } ({ trajetRestant } sec)");
            ConsoleSpinner.Turn();
            Console.ForegroundColor = ConsoleColor.White;
          }
          break;
        default:
          this.Question(map);
          break;
      }
    }

    public void Arrivee()
    {
      this.Etat = Enum.EtatPlayer.Inconnu;
      this.SubZone = this.SubZoneDestination;
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"\nArrivée à la SubZone { this.SubZone }");
      Console.ForegroundColor = ConsoleColor.White;
    }

    public bool CheckDestination()
    {
      // On attend 10 secondes pour le trajet
      return Math.Round(new TimeSpan(DateTime.Now.Ticks - this.action.Ticks).TotalSeconds) > 10;
    }

    public void Question(IMap map)
    {
      int choix = -1;
      Console.WriteLine("\r\nQue voulez-vous faire ?");
      Console.ForegroundColor = ConsoleColor.DarkMagenta;
      Console.Write($"[0] Voir les monstres");
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write(" - ");
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("[1] Changer de zone");
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write(" - ");
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.Write($"[2] Attaquer");
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine();
      choix = int.Parse(Console.ReadLine());

      if (choix == 0)
      {
        map.DumpMonstresSubZone(this.SubZone);
      }
      else if (choix == 1)
      {
        Console.WriteLine("Dans quelle zone voulez-vous vous rendre ?");
        for (int i = 0; i < map.GetNombreSubZone(); i += 1)
        {
          Console.Write($"[{ i }] ");
        }
        Console.WriteLine();
        this.SubZoneDestination = int.Parse(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write($"\r\nDéplacement vers la SubZone { this.SubZoneDestination } (10 sec)");
        Console.ForegroundColor = ConsoleColor.White;
        this.Etat = Enum.EtatPlayer.Mouvement;
        action = DateTime.Now;
      }
      else if (choix == 2)
      {
        if (map.NombreMonstreCurrentSubZoneDecouvert(this.SubZone) == 0)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Il n'y a aucun monstre à attaquer !");
          Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
          map.DumpMonstresSubZoneDecouvert(this.SubZone);
          Console.WriteLine("\r\nQuel monstre voulez-vous attaquer ?");
          int index = 0;
          int choixMonstre = -1;

          foreach (Monstre m in map.GetMonstresSubZoneDecouvert(this.SubZone))
          {
            Console.Write($"[{ index++ }] { m.GetNom() } ");
          }

          Console.WriteLine();
          choixMonstre = int.Parse(Console.ReadLine());

          this.Etat = Enum.EtatPlayer.Attaque;
          action = DateTime.Now;
        }
      }
    }

    public override bool EstDecouvert()
    {
      throw new NotImplementedException();
    }

    public override Enum.EtatMonstre GetEtat()
    {
      throw new NotImplementedException();
    }

    public override int GetTempsDispo()
    {
      throw new NotImplementedException();
    }

    public override double GetTempsRestant()
    {
      throw new NotImplementedException();
    }

    public override Enum.TypeMonstre GetTypeMonstre()
    {
      throw new NotImplementedException();
    }
  }
}
