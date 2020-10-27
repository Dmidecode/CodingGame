using ResumeChapitre1.Sons;
using static ResumeChapitre1.Enum;

namespace ResumeChapitre1.Maps
{
  public class Desert : Map
  {
    public Desert() : base(TypeMap.Desert, (int)SubZoneNombre.Desert)
    {
      this.backgroundTheme = FactorySon.KenTheme;
    }
  }
}
