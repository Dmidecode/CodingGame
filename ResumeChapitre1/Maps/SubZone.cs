using ResumeChapitre1.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeChapitre1.Maps
{
  public class SubZone
  {
    public int Position { get; set; }

    public List<Monstre> Monstres { get; set; }

    public Player Perso { get; set; }

    public SubZone()
    {
      this.Monstres = new List<Monstre>();
    }
  }
}
