using System;

namespace ResumeChapitre1
{
  public static class Enum
  {
    public enum TypeMap
    {
      Foret,
      Desert,
      Cimetiere,
      TerreAncien,
    };

    public enum SubZoneNombre
    {
      Foret = 5,
      Desert = 6,
      Cimetiere = 11,
      TerreAncien = 4
    };

    public enum EtatMonstre
    {
      Inconnu,
      Fuite,
      Mort,
      Vivant
    };

    public enum EtatPlayer
    {
      Inconnu,
      Mouvement,
      Attaque,
    }

    [Flags]
    public enum TypeMonstre
    {
      Carnivore = 0b1,
      Herbivore = 0b10,
      Terrestre = 0b100,
      Volant = 0b1000,
    }
  }
}
