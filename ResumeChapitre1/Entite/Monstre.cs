using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResumeChapitre1.Entite
{
  public abstract class Monstre : Entite
  {
    public delegate void CallRemoveMonstre(Monstre m);
    public event CallRemoveMonstre RemoveMonstre;

    protected int TempsDispo { get; set; }
    protected Enum.EtatMonstre Etat { get; set; }
    protected DateTime TempsCreation { get; set; }
    protected Enum.TypeMonstre Type { get; set; }
    protected List<Enum.TypeMap> Maps { get; set; }
    protected bool Decouvert { get; set; }
    private CancellationTokenSource TokenSource { get; set; }

    public Monstre()
    {
      this.Maps = new List<Enum.TypeMap>();
      this.Etat = Enum.EtatMonstre.Vivant;
      this.TokenSource = new CancellationTokenSource();
    }

    public List<Enum.TypeMap> GetMaps()
    {
      return this.Maps;
    }

    public override Enum.EtatMonstre GetEtat()
    {
      return this.Etat;
    }

    public override Enum.TypeMonstre GetTypeMonstre()
    {
      return this.Type;
    }

    public override int GetTempsDispo()
    {
      return this.TempsDispo;
    }

    public override double GetTempsRestant()
    {
      return Math.Round(TempsDispo - new TimeSpan(DateTime.Now.Ticks - TempsCreation.Ticks).TotalSeconds);
    }

    public void PlayerDecouvert()
    {
      this.Decouvert = true;
    }

    public override bool EstDecouvert()
    {
      return this.Decouvert;
    }

    public void InsertToMap(int subZone, CallRemoveMonstre callbackMonstre)
    {
      this.SubZone = subZone;
      this.TempsCreation = DateTime.Now;
      this.RemoveMonstre += callbackMonstre;
      Task.Run(() =>
      {
        while (this.Etat == Enum.EtatMonstre.Vivant && !this.TokenSource.IsCancellationRequested)
        {
          //this.DumpEtat();
          Thread.Sleep(1000);
          if (this.Pdv <= 0)
            this.Etat = Enum.EtatMonstre.Mort;
          else if (this.GetTempsRestant() < 0)
          {
            this.Fuite();
          }
        }

        if (!this.TokenSource.IsCancellationRequested)
        {
          // Callback pour retirer un monstre de la map
          this.RemoveMonstre(this);
        }
      }, this.TokenSource.Token);
    }

    public void StopWatch()
    {
      this.TokenSource.Cancel();
      this.TokenSource.Dispose();

      // Callback pour retirer un monstre de la map
      this.RemoveMonstre(this);
    }

    public void DumpEtat()
    {
      Console.WriteLine($"Nom: { this.Nom } - Etat: { this.Etat } - Temps avant fuite: { this.GetTempsRestant() } s - SubZone: { this.SubZone }");
    }

    public void Dump()
    {
      switch (this.Etat)
      {
        case Enum.EtatMonstre.Vivant:
          Console.ForegroundColor = ConsoleColor.Green;
          break;
        case Enum.EtatMonstre.Mort:
          Console.ForegroundColor = ConsoleColor.Red;
          break;
        case Enum.EtatMonstre.Fuite:
          Console.ForegroundColor = ConsoleColor.DarkMagenta;
          break;
        default:
          Console.ForegroundColor = ConsoleColor.White;
          break;
      }

      double temps = this.GetTempsRestant() > 0 ? this.GetTempsRestant() : this.TempsDispo;

      Console.WriteLine($"Nom: { this.Nom }");
      Console.WriteLine($"\tPdv: { this.Pdv }");
      Console.WriteLine($"\tNombre de secondes avant fuite: { temps }");
      Console.WriteLine($"\tAttaque: { this.Attaque }");
      Console.WriteLine($"\tSon état: { this.Etat }");
      Console.WriteLine($"\tDécouvert ?: { this.Decouvert }");
      Console.WriteLine($"\tSon type: { this.Type }");
      Console.ForegroundColor = ConsoleColor.White;
    }

    public void Fuite()
    {
      Console.ForegroundColor = ConsoleColor.DarkRed;
      this.Etat = Enum.EtatMonstre.Fuite;
      Console.WriteLine($"'{ this.Nom }' s'est enfui");
      Console.ForegroundColor = ConsoleColor.White;
    }
  }
}
