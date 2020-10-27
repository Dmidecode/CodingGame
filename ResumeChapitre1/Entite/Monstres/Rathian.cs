using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeChapitre1.Entite.Monstres
{
  public class Rathian : Monstre
  {
    public Rathian()
    {
      this.Nom = "Rathian";
      this.Pdv = 20;
      this.Attaque = 7;
      this.TempsDispo = 120;
      this.Type = Enum.TypeMonstre.Carnivore | Enum.TypeMonstre.Volant | Enum.TypeMonstre.Terrestre;
      this.Maps.AddRange(new[] { Enum.TypeMap.Foret, Enum.TypeMap.Desert });
    }
  }
}
