using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeChapitre1.Entite.Monstres
{
  public class Nergigante : Monstre
  {
    public Nergigante()
    {
      this.Nom = "Nergigante";
      this.Pdv = 50;
      this.Attaque = 20;
      this.TempsDispo = 240;
      this.Type = Enum.TypeMonstre.Herbivore | Enum.TypeMonstre.Volant | Enum.TypeMonstre.Terrestre;
      this.Maps.AddRange(new[] { Enum.TypeMap.TerreAncien });
    }
  }
}
