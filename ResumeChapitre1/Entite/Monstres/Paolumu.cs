using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeChapitre1.Entite.Monstres
{
  public class Paolumu : Monstre
  {
    public Paolumu()
    {
      this.Nom = "Paolumu";
      this.Pdv = 20;
      this.Attaque = 6;
      this.TempsDispo = 120;
      this.Type = Enum.TypeMonstre.Herbivore | Enum.TypeMonstre.Terrestre;
      this.Maps.AddRange(new[] { Enum.TypeMap.Foret, Enum.TypeMap.Cimetiere });
    }
  }
}
