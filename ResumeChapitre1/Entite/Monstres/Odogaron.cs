using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeChapitre1.Entite.Monstres
{
  public class Odogaron : Monstre
  {
    public Odogaron()
    {
      this.Nom = "Odogaron";
      this.Pdv = 30;
      this.Attaque = 12;
      this.TempsDispo = 180;
      this.Type = Enum.TypeMonstre.Carnivore | Enum.TypeMonstre.Terrestre;
      this.Maps.AddRange(new[] { Enum.TypeMap.Foret, Enum.TypeMap.Desert, Enum.TypeMap.Cimetiere, Enum.TypeMap.TerreAncien });
    }
  }
}
