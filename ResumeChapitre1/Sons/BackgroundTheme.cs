using System;
using System.Windows.Media;

namespace ResumeChapitre1.Sons
{
  public class BackgroundTheme : Son
  {
    public BackgroundTheme(string son) : base(son)
    {
    }

    public override void InitialiseSon()
    {
      base.InitialiseSon();
    }

    public override void Play()
    {
      this.backgroundMusic.PlayLooping();
    }
  }
}
