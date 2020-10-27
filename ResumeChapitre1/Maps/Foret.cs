using ResumeChapitre1.Sons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ResumeChapitre1.Enum;

namespace ResumeChapitre1.Maps
{
  public class Foret : Map
  {
    public Foret() : base(TypeMap.Foret, (int)SubZoneNombre.Foret)
    {
      this.backgroundTheme = FactorySon.RyuTheme;
    }
  }
}
