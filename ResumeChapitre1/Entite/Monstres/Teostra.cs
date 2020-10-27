using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeChapitre1.Entite.Monstres
{
  public class Teostra : Monstre
  {
    public Teostra()
    {
      this.Nom = "Teostra";
      this.Pdv = 50;
      this.Attaque = 18;
      this.TempsDispo = 240;
      this.Type = Enum.TypeMonstre.Carnivore | Enum.TypeMonstre.Volant | Enum.TypeMonstre.Terrestre;
      this.Maps.Add(Enum.TypeMap.TerreAncien);
    }
  }
}
