using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeChapitre1.Entite
{
  public abstract class Entite : IEntite
  {
    protected string Nom { get; set; }
    protected int Pdv { get; set; }
    protected int Attaque { get; set; }
    protected decimal CoolDown { get; set; }
    protected int SubZone { get; set; }

    public int GetAttaque()
    {
      return this.Attaque;
    }

    public string GetNom()
    {
      return this.Nom;
    }

    public int GetPdv()
    {
      return this.Pdv;
    }

    public decimal GetCooldown()
    {
      return this.CoolDown;
    }

    public int GetSubZone()
    {
      return this.SubZone;
    }

    public abstract bool EstDecouvert();
    public abstract Enum.EtatMonstre GetEtat();
    public abstract Enum.TypeMonstre GetTypeMonstre();
    public abstract int GetTempsDispo();
    public abstract double GetTempsRestant();
  }
}
