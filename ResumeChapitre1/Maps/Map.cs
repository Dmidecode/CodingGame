using ResumeChapitre1.Entite;
using ResumeChapitre1.Entite.Monstres;
using ResumeChapitre1.Sons;
using System;
using System.Collections.Generic;
using System.Linq;
using static ResumeChapitre1.Enum;

namespace ResumeChapitre1.Maps
{
  public abstract class Map : IMap
  {
    TypeMap typemap;
    protected BackgroundTheme backgroundTheme;
    SubZone[] Subzones;
    bool alive;
    Player player;

    public Map(TypeMap typemap, int nombreSubZone)
    {
      this.typemap = typemap;
      this.NombreSubZone = nombreSubZone;
      this.Subzones = new SubZone[nombreSubZone];
      for (int i = 0; i < nombreSubZone; i += 1)
      {
        this.Subzones[i] = new SubZone
        {
          Position = i
        };
      }
    }

    public int NombreSubZone { get; set; }

    public TypeMap CurrentMap()
    {
      return this.typemap;
    }

    public int GetNombreSubZone()
    {
      return this.NombreSubZone;
    }

    public string GetNomMap()
    {
      return this.typemap.ToString();
    }

    public List<Monstre> GetMonstres()
    {
      return this.Subzones.SelectMany(x => x.Monstres).ToList();
    }

    public List<Monstre> GetMonstresSubZone(int subzone)
    {
      return this.Subzones[subzone].Monstres;
    }

    public List<Monstre> GetMonstresSubZoneDecouvert(int subzone)
    {
      return this.Subzones[subzone].Monstres.Where(x => x.EstDecouvert()).ToList();
    }

    public int NombreMonstreCurrentMap()
    {
      return this.GetMonstres().Count();
    }

    public int NombreMonstreCurrentSubZone(int subZone)
    {
      return this.Subzones[subZone].Monstres.Count;
    }

    public int NombreMonstreCurrentSubZoneDecouvert(int subZone)
    {
      return this.Subzones[subZone].Monstres.Where(x => x.EstDecouvert()).ToList().Count;
    }

    public List<Monstre> GetMonstresTypeMap()
    {
      return FactoryMonstre.ListeMonstres().Where(x => x.GetMaps().Contains(this.typemap)).ToList();
    }

    public void AddMonstre()
    {
      int subZonePop = new Random().Next(0, this.NombreSubZone);
      //int nombreIndexMonstre = 0;
      int nombreIndexMonstre = new Random().Next(0, this.GetMonstresTypeMap().Count);

      Monstre m = this.GetMonstresTypeMap().ElementAt(nombreIndexMonstre);

      // Lance le check du monstre toutes les secondes
      m.InsertToMap(subZonePop, RemoveMonstre);
      this.Subzones[subZonePop].Monstres.Add(m);

      int currentLineCursor = Console.CursorTop;
      Console.SetCursorPosition(0, Console.CursorTop);
      Console.Write(new string(' ', Console.WindowWidth));
      Console.SetCursorPosition(0, currentLineCursor);
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine($"{ m.GetNom() } vient d'apparaitre en SubZone { subZonePop }");
      Console.ForegroundColor = ConsoleColor.White;
    }

    public void AddPlayer()
    {
      this.player = new Player();
    }

    public virtual void Start()
    {
      this.AddPlayer();
      this.AddMonstre();
      this.backgroundTheme.Play();
      this.alive = true;
    }

    public void Stop()
    {
      this.backgroundTheme.Stop();
      this.alive = false;
      this.GetMonstres().ForEach(x => x.StopWatch());
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("\t------- TEMPS ECOULÉ -------");
      Console.ForegroundColor = ConsoleColor.DarkMagenta;
      Console.WriteLine($"Il y a { this.NombreMonstreCurrentMap() } monstres restants");
      Console.ForegroundColor = ConsoleColor.White;
    }

    public bool IsAlive()
    {
      return this.alive;
    }

    public void DumpMonstres()
    {
      foreach (Monstre m in this.GetMonstresTypeMap())
      {
        m.Dump();
      }
    }

    public void DumpMonstresSubZone(int subzone)
    {
      if (this.NombreMonstreCurrentSubZone(subzone) == 0)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Aucun monstre n'est dans la zone !");
        Console.ForegroundColor = ConsoleColor.White;
      }
      else
      {
        foreach (Monstre m in this.Subzones[subzone].Monstres)
        {
          m.Dump();
          m.PlayerDecouvert();
        }
      }
    }

    public void DumpMonstresSubZoneDecouvert(int subzone)
    {
      foreach (Monstre m in this.Subzones[subzone].Monstres.Where(x => x.EstDecouvert()))
      {
        m.Dump();
      }
    }

    public void RemoveMonstre(Monstre monstre)
    {
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine($"'{ monstre.GetNom() }' est parti de la SubZone { monstre.GetSubZone() }");
      Console.ForegroundColor = ConsoleColor.White;
    }

    public void Play()
    {
      this.player.Play(this);
    }
  }
}
