using Core.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Core.Infra.CC.Testes
{
  [TestClass]
  public class XEventoTestes
  {
    [TestMethod, TestCategory("Core"), TestProperty("Autor", "Wagner")]
    [Description("Cria evento com nome menor que tres caracteres")]
    public void TesteNomeEventoInValido()
    {
      var evento = new Evento("No", "Curso", DateTime.Now, DateTime.Now, false, 40, true, "Wagner");
      Assert.IsFalse(evento.EhValido());
    }

    [TestMethod, TestCategory("Core"), TestProperty("Autor", "Wagner")]
    [Description("Cria evento com nome menor que tres caracteres e marcar gratuito inserindo um valor")]
    public void TesteNomeValorInValido()
    {
      var evento = new Evento("No", "Curso", DateTime.Now, DateTime.Now, true, 40, true, "Wagner");
      Assert.IsFalse(evento.EhValido());
      Assert.AreEqual(evento.ErrosValidacao.Count, 2);
    }

    [TestMethod, TestCategory("Core"), TestProperty("Autor", "Wagner")]
    [Description("Cria evento com nome maior que tres caracteres")]
    public void TesteNomeEventoValido()
    {
      var evento = new Evento("Nome", "Curso", DateTime.Now, DateTime.Now, false, 40, true, "Wagner");
      Assert.IsTrue(evento.EhValido());
    }
  }
}
