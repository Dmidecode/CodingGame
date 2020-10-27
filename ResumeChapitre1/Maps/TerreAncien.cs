using ResumeChapitre1.Sons;
using static ResumeChapitre1.Enum;

namespace ResumeChapitre1.Maps
{
  public class TerreAncien : Map
  {
    public TerreAncien() : base(TypeMap.TerreAncien, (int)SubZoneNombre.TerreAncien)
    {
      this.backgroundTheme = FactorySon.BalrogTheme;
    }
  }
}
