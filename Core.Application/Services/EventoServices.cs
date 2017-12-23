using Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Application.ViewModels;
using Core.Domain.Core.Bus;
using Core.Domain.Eventos.Commands;

namespace Core.Application.Services
{
  public class EventoServices : IEventoServices
  {
    private readonly IBus _bus;
    public EventoServices(IBus bus)
    {
      _bus = bus;
    }
    public void Registrar(EventoViewModel eventoViewModel)
    {
      //var registroCommando = new RegistrarEventoCommand();
      //_bus.SendCommand(registroCommando);
    }

    public EventoViewModel ObterPorId(Guid id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<EventoViewModel> ObterTodos()
    {
      throw new NotImplementedException();
    }

    public void Atualizar(EventoViewModel eventoViewModel)
    {
      throw new NotImplementedException();
    }

    public void Excluir(Guid id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<EventoViewModel> ObterEventoPorOrganizador(Guid organizadorId)
    {
      throw new NotImplementedException();
    }
// Minuto 41:44 aula 14
    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}
