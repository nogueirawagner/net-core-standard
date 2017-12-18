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
        "Legal", DateTime.Now.AddDays(12), DateTime.Now.AddDays(13), true, 0, true, "Wagner Nogueira");
      bus.SendCommand(cmd);
    }

    [TestMethod]
    public void CriaRegistroFalho()
    {
      var bus = new FakeBus();
      //Criar o comando de registro com sucesso
      var cmd = new RegistrarEventoCommand(
        "Legal", DateTime.Now.AddDays(12), DateTime.Now.AddDays(13), true, 0, true, "Wagner Nogueira");
      bus.SendCommand(cmd);
    }


    [TestMethod]
    public void AtualizarEvento()
    {
      var bus = new FakeBus();
      //Criar o comando de registro com sucesso
      var cmd = new RegistrarEventoCommand(
          "Legal", DateTime.Now.AddDays(12), DateTime.Now.AddDays(13), true, 0, true, "Wagner Nogueira");
      bus.SendCommand(cmd);

      var att = new AtualizarEventoCommand(cmd.Id, "Legal", "Descricao", "Desc", DateTime.Now.AddDays(12), DateTime.Now.AddDays(13), true, 0, true, "Wagner Nogueira");
      bus.SendCommand(att);
    }

    [TestMethod]
    public void ExcluirEvento()
    {
      var bus = new FakeBus();
      //Criar o comando de registro com sucesso
      var cmd = new RegistrarEventoCommand(
        "Legal", DateTime.Now.AddDays(12), DateTime.Now.AddDays(13), true, 0, true, "Wagner Nogueira");
      bus.SendCommand(cmd);

      var excluir = new ExcluirEventoCommand(cmd.Id);
      bus.SendCommand(excluir);

    }
  }

}
