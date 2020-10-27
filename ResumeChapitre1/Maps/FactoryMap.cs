using ResumeChapitre1.Sons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ResumeChapitre1.Enum;

namespace ResumeChapitre1.Maps
{
  public static class FactoryMap
  {

    public static IMap Generate(TypeMap typeMap)
    {
      switch (typeMap)
      {
        case TypeMap.Foret:
          return new Foret();
        case TypeMap.Desert:
          return new Desert();
        case TypeMap.Cimetiere:
          return new Cimetiere();
        default:
          return new TerreAncien();
      }
    }

    public static void StartMap(IMap map)
    {
      map.Start();
      Task.Run(() => FactoryMap.ManageMap(map));
    }

    public static void CheckMap(IMap map)
    {
      while (map.IsAlive())
      {
        map.Play();
      }
    }

    public static void StopMap(IMap map)
    {

    }

    public static void ManageMap(IMap map)
    {
      Thread.Sleep(30000);

      // Pop du premier monstre au bout de 30 secondes
      map.AddMonstre();
      FactorySon.NewWarriorEnteredRing.Play();
      Thread.Sleep(30000);

      // Pop du premier monstre au bout de 30 secondes
      map.AddMonstre();
      FactorySon.NewWarriorEnteredRing.Play();
      Thread.Sleep(30000);

      // Pop du premier monstre au bout de 30 secondes
      map.AddMonstre();
      FactorySon.NewWarriorEnteredRing.Play();
      Thread.Sleep(30000);

      map.Stop();
    }
  }
}
