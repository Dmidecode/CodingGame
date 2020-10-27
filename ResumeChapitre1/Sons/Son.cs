using System;
using System.Media;
using System.Windows.Media;

namespace ResumeChapitre1.Sons
{
  public class Son
  {
    // On prend toujours le même répertoire de base pour charger les musiques
    private readonly string baseRepertoire = $"{ System.AppDomain.CurrentDomain.BaseDirectory }Ressources/Musiques/";

    protected SoundPlayer backgroundMusic;

    public Son(string son)
    {
      this.Nom = son;
    }

    public string Nom { get; set; }

    public virtual void InitialiseSon()
    {
      this.backgroundMusic = new SoundPlayer
      {
        SoundLocation = $"{ baseRepertoire }{ this.Nom }"
      };

      this.backgroundMusic.Load();
    }

    public virtual void Play()
    {
      this.backgroundMusic.Play();
    }

    public void Stop()
    {
      this.backgroundMusic.Stop();
    }
  }
}
