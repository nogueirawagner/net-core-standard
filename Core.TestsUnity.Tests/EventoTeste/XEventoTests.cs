using Core.Domain.Eventos.Commands;
using Core.Domain.Models;
using Core.Domain.Models.Eventos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Core.TestsUnity.Tests.EventoTeste
{
  [TestClass]
  public class XEventoTests
  {
    [TestMethod]
    public void CriaRegistro()
    {
      var bus = new FakeBus();
      //Criar o comando de registro com sucesso
      var cmd = new RegistrarEventoCommand(
        "Nome do Evento", "Descricao Evento", "Desc Event", DateTime.Now.AddDays(20), DateTime.Now.AddDays(20), true,
        0, true, "Wagner Nogueira", Guid.Empty, Guid.Empty, null);
      bus.SendCommand(cmd);
    }

    [TestMethod]
    public void CriaRegistroFalho()
    {
      var bus = new FakeBus();
      //Criar o comando de registro com sucesso
      var cmd = new RegistrarEventoCommand(
        "Nome do Evento", "Descricao Evento", "Desc Event", DateTime.Now.AddDays(20), DateTime.Now.AddDays(20), true,
        0, true, "Wagner Nogueira", Guid.Empty, Guid.Empty, null);
      bus.SendCommand(cmd);
    }
    
    [TestMethod, TestCategory("Evento"), TestProperty("Autor", "Wagner")]
    [Description("Atualizar evento")]
    public void AtualizarEvento()
    {
      var bus = new FakeBus();
      //Criar o comando de registro com sucesso
      var cmd = new RegistrarEventoCommand(
          "Nome do Evento", "Descricao Evento", "Desc Event", DateTime.Now.AddDays(20), DateTime.Now.AddDays(20), true,
        0, true, "Wagner Nogueira", Guid.Empty, Guid.Empty, null);
      bus.SendCommand(cmd);

      var att = new AtualizarEventoCommand(cmd.Id, "Legal", "Descricao", "Desc", DateTime.Now.AddDays(12), DateTime.Now.AddDays(13), true, 0, true, "Wagner Nogueira", Guid.Empty, Guid.Empty);
      bus.SendCommand(att);
    }

    [TestMethod, TestCategory("Evento"), TestProperty("Autor", "Wagner")]
    [Description("Excluir evento")]
    public void ExcluirEvento()
    {
      var bus = new FakeBus();
      //Criar o comando de registro com sucesso
      var cmd = new RegistrarEventoCommand(
        "Nome do Evento", "Descricao Evento", "Desc Event", DateTime.Now.AddDays(20), DateTime.Now.AddDays(20), true,
        0, true, "Wagner Nogueira", Guid.Empty, Guid.Empty, null);
      bus.SendCommand(cmd);

      var excluir = new ExcluirEventoCommand(cmd.Id);
      bus.SendCommand(excluir);

    }
  }

}
