using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeChapitre1.Sons
{
  public static class FactorySon
  {
    public static BackgroundTheme BalrogTheme = new BackgroundTheme("BalrogTheme.wav");
    public static BackgroundTheme GuileTheme = new BackgroundTheme("GuildeTheme.wav");
    public static BackgroundTheme KenTheme = new BackgroundTheme("KenTheme.wav");
    public static BackgroundTheme RyuTheme = new BackgroundTheme("RyuTheme.wav");

    public static Son NewWarriorEnteredRing = new Son("ANewWarriorHasEnteredTheRing.wav");

    public static void Chargement()
    {
      BalrogTheme.InitialiseSon();
      GuileTheme.InitialiseSon();
      KenTheme.InitialiseSon();
      RyuTheme.InitialiseSon();
      NewWarriorEnteredRing.InitialiseSon();
    }
  }
}
