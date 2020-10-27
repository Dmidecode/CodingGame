using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeChapitre1.Entite.Monstres
{
  public static class FactoryMonstre
  {
    public static IEnumerable<Monstre> ListeMonstres()
    {
      yield return new Anjanath();
      yield return new Barroth();
      yield return new Diablos();
      yield return new Jagras();
      yield return new Nergigante();
      yield return new Odogaron();
      yield return new Paolumu();
      yield return new Rathian();
      yield return new Teostra();
    }
  }
}
