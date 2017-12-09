using Core.Domain.Models;
using System;

namespace Core.Domain.ConsoleTesting
{
  class Program
  {
    static void Main(string[] args)
    {
      var evento = new Evento("Nome Evento", "Curso", DateTime.Now, DateTime.Now, false, 40, true, "Wagner");
      var evento2 = evento;

      Console.WriteLine(evento.ToString());
      Console.WriteLine(evento.Equals(evento2));
      Console.ReadKey();
    }
  }
}
