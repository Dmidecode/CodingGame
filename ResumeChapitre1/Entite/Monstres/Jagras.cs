using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeChapitre1.Entite.Monstres
{
  public class Jagras : Monstre
  {
    public Jagras()
    {
      this.Nom = "Jagras";
      this.Pdv = 10;
      this.Attaque = 1;
      this.TempsDispo = 60;
      this.Type = Enum.TypeMonstre.Herbivore | Enum.TypeMonstre.Terrestre;
      this.Maps.AddRange(new[] { Enum.TypeMap.Foret, Enum.TypeMap.Desert, Enum.TypeMap.Cimetiere, Enum.TypeMap.TerreAncien });
    }
  }
}
