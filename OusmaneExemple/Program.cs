using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace TestSelectMany
{
  class Program
  {
    static void Main(string[] args)
    {
      List<string> urls = new List<string>
      {
        @"C:\Users\Megumin\Desktop\json.txt",
        @"C:\Users\Megumin\Desktop\json - modification.txt",
        @"C:\Users\Megumin\Desktop\json - ventilation.txt"
      };

      GettxtAsync(urls);
      Console.WriteLine("Main :)");
      while (true) ;
      Console.ReadKey();
    }

    private static async Task GettxtAsync(List<string> urls)
    {
      List<Task<string>> tasks = new List<Task<string>>();
      Console.WriteLine("Début lecture des fichiers");
      foreach (var url in urls)
      {
        Task<string> fichierCharge = Download(url);
        Task<string> fichierCharge2 = fichierCharge.ContinueWith(fichierEncours =>
        {
          Notifier(fichierEncours.Result);
          return fichierEncours.Result;
        });

        tasks.Add(fichierCharge2);
      }

      //foreach (Task task in tasks)
      //{
      //  task.Start();
      //}

      await Task.WhenAll(tasks.ToArray());
      Console.WriteLine("Fini :)");
    }

    private static Task Notifier(string fichier)
    {
      Thread.Sleep(5000);
      Console.WriteLine($"le fichier : {fichier} a été traité");
      return Task.FromResult($"fichier en cours de téléchargement {fichier}");
    }

    private void sendMail(string fichierCharge)
    {
      Console.WriteLine("Prêt à envoyer le mail");
      SmtpClient smpt = new SmtpClient();
      smpt.Port = 25;
      smpt.SendMailAsync(@"bmira@flag-systemes.com", @"bmira@flag-systemes.com", @"Test envoie fichier chargé", $@"{fichierCharge}");
    }

    private static Task<string> Download(string path)
    {
      var textRecup = new StreamReader(path);
        return Task.Run(() =>
        {
          var txt = textRecup.ReadToEnd();
          Thread.Sleep(10000);
          Console.WriteLine($"Fichier téléchargé");
          return "Test";
        });
    }

    private static Task<string> TestOtherTask(string path)
    {
      return Task.Run(() =>
      {
        Console.WriteLine("TestOtherTask {0}", path);
        return path;
      });
    }
  }
}
