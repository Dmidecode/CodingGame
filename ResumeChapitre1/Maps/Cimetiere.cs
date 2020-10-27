using ResumeChapitre1.Sons;
using static ResumeChapitre1.Enum;

namespace ResumeChapitre1.Maps
{
  public class Cimetiere : Map
  {
    public Cimetiere() : base(TypeMap.Cimetiere, (int)SubZoneNombre.Cimetiere)
    {
      this.backgroundTheme = FactorySon.GuileTheme;
    }
  }
}
