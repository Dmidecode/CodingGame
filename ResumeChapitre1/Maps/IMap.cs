using ResumeChapitre1.Entite;
using System.Collections.Generic;
using static ResumeChapitre1.Enum;

namespace ResumeChapitre1.Maps
{
  public interface IMap
  {
    TypeMap CurrentMap();

    string GetNomMap();

    int GetNombreSubZone();

    int NombreMonstreCurrentMap();

    int NombreMonstreCurrentSubZone(int subZone);

    int NombreMonstreCurrentSubZoneDecouvert(int subZone);

    List<Monstre> GetMonstresTypeMap();

    List<Monstre> GetMonstres();

    List<Monstre> GetMonstresSubZone(int subzone);

    List<Monstre> GetMonstresSubZoneDecouvert(int subzone);

    void Start();

    void Stop();

    bool IsAlive();

    void DumpMonstres();

    void DumpMonstresSubZone(int subzone);

    void DumpMonstresSubZoneDecouvert(int subzone);

    void AddMonstre();

    void Play();
  }
}
