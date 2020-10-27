using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeChapitre1.Entite.Monstres
{
  public class Anjanath : Monstre
  {
    public Anjanath()
    {
      this.Nom = "Anjanath";
      this.Pdv = 20;
      this.Attaque = 5;
      this.TempsDispo = 90;
      this.Type = Enum.TypeMonstre.Carnivore | Enum.TypeMonstre.Terrestre;
      this.Maps.AddRange(new[] { Enum.TypeMap.Foret, Enum.TypeMap.Cimetiere, Enum.TypeMap.TerreAncien });
    }
  }
}
