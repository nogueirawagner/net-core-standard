using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Domain.Core.Bus;
using Core.Domain.Core.Commands;
using Core.Domain.Core.Events;
using Core.Domain.Core.Notifications;
using Core.Domain.Eventos.Commands;
using Core.Domain.Models.Eventos;
using Core.Domain.Eventos.Repository;
using Core.Domain.Interfaces;
using Core.Domain.Eventos.Events;

namespace Core.TestsUnity.Tests.EventoTeste
{
  public class FakeBus : IBus
  {
    public void RaiseEvent<T>(T theEvent) where T : Event
    {
      Publish(theEvent);
    }

    public void SendCommand<T>(T theCommand) where T : Command
    {
      Publish(theCommand);
    }

    private static void Publish<T>(T message) where T : Message
    {
      var msgType = message.MessageType;

      if (msgType.Equals("DomainNotification"))
      {
        var obj = new DomainNotificationHandler();
        ((IDomainNotificationHandler<T>)obj).Handle(message);
      }

      if (msgType.Equals("RegistrarEventoCommand")
        || msgType.Equals("AtualizarEventoCommand")
        || msgType.Equals("ExcluirEventoCommand"))
      {
        //var obj = new EventoCommandHandler(new FakeEventoRepository(), new FakeUOW(), new FakeBus(), new DomainNotificationHandler());
        //((IHandler<T>)obj).Handle(message);
      }

      if (msgType.Equals("EventoRegistradoEvent")
       || msgType.Equals("EventoAtualizadoEvent")
       || msgType.Equals("EventoExcluidoEvent"))
      {
        var obj = new EventoEventHandler();
        ((IHandler<T>)obj).Handle(message);
      }

    }
  }
  public class FakeEventoRepository : IEventoRepository
  {
    public void Adicionar(Evento obj)
    {
    }

    public void AdicionarEndereco(Endereco endereco)
    {
    }

    public void Atualizar(Evento obj)
    {
    }

    public void AtualizarEndereco(Endereco endereco)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Evento> Buscar(Expression<Func<Evento, bool>> predicate)
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Categoria> ObterCategorias()
    {
      throw new NotImplementedException();
    }

    public Endereco ObterEnderecoPorId(Guid id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId)
    {
      throw new NotImplementedException();
    }

    public Evento ObterPorId(Guid id)
    {
      return new Evento("Fake", "News", DateTime.Now, DateTime.Now, true, 0, true, "Aberlado");
    }

    public IEnumerable<Evento> ObterTodos()
    {
      return null;
    }

    public void Remover(Guid id)
    {
    }

    public int SaveChanges()
    {
      throw new NotImplementedException();
    }
  }

  public class FakeUOW : IUnitOfWork
  {
    public CommandResponse Commit()
    {
      return new CommandResponse(true);
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}
