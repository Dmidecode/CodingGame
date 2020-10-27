using static ResumeChapitre1.Enum;

namespace ResumeChapitre1
{
  public static class Extensions
  {
    static public string ToString(this TypeMap typemap)
    {
      switch (typemap)
      {
        case TypeMap.Foret:
          return "Forêt";
        case TypeMap.Desert:
          return "Désert";
        case TypeMap.Cimetiere:
          return "Cimetière";
        case TypeMap.TerreAncien:
          return "Terre ancienne";
        default:
          return "Inconnu";
      }
    }

    static public bool IsForet(this TypeMap typemap)
    {
      return typemap == TypeMap.Foret;
    }

    static public bool IsDesert(this TypeMap typemap)
    {
      return typemap == TypeMap.Desert;
    }

    static public bool IsCimetiere(this TypeMap typemap)
    {
      return typemap == TypeMap.Cimetiere;
    }

    static public bool IsTerreAncienne(this TypeMap typemap)
    {
      return typemap == TypeMap.TerreAncien;
    }

    static public bool IsCarnivore(this TypeMonstre monstre)
    {
      return (monstre & TypeMonstre.Carnivore) == TypeMonstre.Carnivore;
    }

    static public bool IsHerbivore(this TypeMonstre monstre)
    {
      return (monstre & TypeMonstre.Herbivore) == TypeMonstre.Herbivore;
    }

    static public bool IsTerrestre(this TypeMonstre monstre)
    {
      return (monstre & TypeMonstre.Terrestre) == TypeMonstre.Terrestre;
    }

    static public bool IsVolant(this TypeMonstre monstre)
    {
      return (monstre & TypeMonstre.Volant) == TypeMonstre.Volant;
    }
  }
}
