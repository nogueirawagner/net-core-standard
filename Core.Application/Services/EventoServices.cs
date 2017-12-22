using Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Application.ViewModels;

namespace Core.Application.Services
{
  public class EventoServices : IEventoServices
  {
    public void Registrar(EventoViewModel eventoViewModel)
    {
      throw new NotImplementedException();
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
