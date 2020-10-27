using static ResumeChapitre1.Enum;

namespace ResumeChapitre1.Entite
{
  public interface IEntite
  {
    int GetPdv();

    string GetNom();

    int GetAttaque();

    int GetTempsDispo();

    double GetTempsRestant();

    EtatMonstre GetEtat();

    TypeMonstre GetTypeMonstre();

    bool EstDecouvert();

    decimal GetCooldown();
  }
}
