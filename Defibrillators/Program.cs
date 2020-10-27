using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


class Solution
{
  static List<string> descriptionDefibrillateur = new List<string>() {
    "1;Maison de la Prevention Sante;6 rue Maguelone 340000 Montpellier;;3,87952263361082;43,6071285339217",
    "2;Hotel de Ville;1 place Georges Freche 34267 Montpellier;;3,89652239197876;43,5987299452849",
    "3;Zoo de Lunaret;50 avenue Agropolis 34090 Mtp;;3,87388031141133;43,6395872778854",
  };

  static void Main(string[] args)
  {
    double LON = double.Parse(args[0]);
    double LAT = double.Parse(args[1]);
    int N = int.Parse(args[2]);
    List<AdresseData> adresses = new List<AdresseData>();
    double max = double.MaxValue;
    int res = 0;
    for (int i = 0; i < descriptionDefibrillateur.Count(); i++)
    {
      //string DEFIB = Console.ReadLine();
      double calc = double.MaxValue;
      AdresseData data = new AdresseData(descriptionDefibrillateur[i]);

      calc = CalcDistance(LON, LAT, data.Longitude, data.Latitude);

      if (calc < max)
      {
        max = calc;
        res = i;
      }

      adresses.Add(data);
    }
    
    Console.WriteLine(adresses[res].Nom);
    Console.ReadLine();
  }

  public static double CalcDistance(double longitudeA, double latitudeA, double longitudeB, double latitudeB)
  {
    double x = (longitudeB - longitudeA) * Math.Cos((latitudeA + latitudeB) / 2);
    double y = latitudeB - latitudeA;
    return (Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(y, 2.0))) * 6371;
  }

  public class AdresseData
  {
    public AdresseData(string fullAdresse)
    {
      string[] splits = fullAdresse.Split(new char[] { ';' });

      // Id
      this.Id = int.Parse(splits[0]);

      // Le nom de la résidence
      this.Nom = splits[1];

      // L'adresse
      this.Adresse = splits[2];

      // Le téléphone
      this.Telephone = splits[3];

      // La longitude
      this.Longitude = double.Parse(splits[4]);

      // La latitude
      this.Latitude = double.Parse(splits[5]);
    }

    public int Id { get; set; }
    public string Nom { get; set; }
    public string Adresse { get; set; }
    public string Telephone { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
  }
}