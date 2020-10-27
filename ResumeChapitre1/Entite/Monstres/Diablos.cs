using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeChapitre1.Entite.Monstres
{
  public class Diablos : Monstre
  {
    public Diablos()
    {
      this.Nom = "Diablos";
      this.Pdv = 30;
      this.Attaque = 4;
      this.TempsDispo = 120;
      this.Type = Enum.TypeMonstre.Herbivore | Enum.TypeMonstre.Volant | Enum.TypeMonstre.Terrestre;
      this.Maps.AddRange(new[] { Enum.TypeMap.Desert, Enum.TypeMap.TerreAncien });
    }
  }
}
