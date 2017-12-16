using Core.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Core.TestsUnity.Tests.EventoTeste
{
  [TestClass]
  public class XEventoTests
  {
    [TestMethod, TestCategory("Core"), TestProperty("Autor", "Wagner")]
    [Description("Cria evento com nome menor que tres caracteres")]
    public void TesteNomeEventoInValido()
    {
      var evento = new Evento("No", "Curso", DateTime.Now, DateTime.Now, false, 40, true, "Wagner");
      evento.EhValido();
      Assert.IsFalse(evento.ValidationResult.IsValid);
      Assert.AreEqual(evento.ValidationResult.Errors.Count, 1);
      Assert.AreEqual(evento.ValidationResult.Errors.First().ErrorMessage, "O nome deve conter entre 3 e 150 caracteres");
    }

    [TestMethod, TestCategory("Core"), TestProperty("Autor", "Wagner")]
    [Description("Cria evento com nome menor que tres caracteres e marcar gratuito inserindo um valor")]
    public void TesteNomeValorInValido()
    {
      var evento = new Evento("No", "Curso", DateTime.Now, DateTime.Now, true, 40, true, "Wagner");
      evento.EhValido();
      Assert.IsFalse(evento.ValidationResult.IsValid);
      Assert.AreEqual(evento.ValidationResult.Errors.Count, 2);
      Assert.AreEqual(evento.ValidationResult.Errors.First(s => s.PropertyName == "Nome").ErrorMessage, "O nome deve conter entre 3 e 150 caracteres");
      Assert.AreEqual(evento.ValidationResult.Errors.First(s => s.PropertyName == "Valor").ErrorMessage, "O valor deve ser zero para evento gratuito");
    }

    [TestMethod, TestCategory("Core"), TestProperty("Autor", "Wagner")]
    [Description("Cria evento com nome maior que tres caracteres")]
    public void TesteNomeEventoValido()
    {
      var evento = new Evento("Nome", "Curso", DateTime.Now, DateTime.Now, false, 40, true, "Wagner");
      evento.EhValido();
      Assert.IsTrue(evento.ValidationResult.IsValid);
    }
  }
}
