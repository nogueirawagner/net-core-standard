using Core.Domain.Core.Events;
using Core.Domain.Eventos.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Eventos.EventHandlers
{
  public class EventoEventHandler :
    IHandler<EventoRegistradoEvent>,
    IHandler<EventoAtualizadoEvent>,
    IHandler<EventoExcluidoEvent>
  {
    public void Handle(EventoRegistradoEvent message)
    {
      // Enviar um e-mail
      // Fazer um log ..
    }

    public void Handle(EventoAtualizadoEvent message)
    {
      // Enviar um e-mail
      // Fazer um log ..
    }

    public void Handle(EventoExcluidoEvent message)
    {
      // Enviar um e-mail
      // Fazer um log ..
    }
  }
}
