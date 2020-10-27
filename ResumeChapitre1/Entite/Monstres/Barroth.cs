using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeChapitre1.Entite.Monstres
{
  public class Barroth : Monstre
  {
    public Barroth()
    {
      this.Nom = "Barroth";
      this.Pdv = 15;
      this.Attaque = 3;
      this.TempsDispo = 90;
      this.Type = Enum.TypeMonstre.Herbivore | Enum.TypeMonstre.Terrestre;
      this.Maps.AddRange(new[] { Enum.TypeMap.Desert });
    }
  }
}
