﻿using Core.Domain.Core.Events;

namespace Core.Domain.Eventos.Events
{
  public class EventoEventHandler :
    IHandler<EventoRegistradoEvent>,
    IHandler<EventoAtualizadoEvent>,
    IHandler<EventoExcluidoEvent>,
    IHandler<EnderecoAdicionadoEvent>,
    IHandler<EnderecoAtualizadoEvent>
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

    public void Handle(EnderecoAtualizadoEvent message)
    {
      // Enviar um e-mail
      // Fazer um log ..
    }

    public void Handle(EnderecoAdicionadoEvent message)
    {
      // Enviar um e-mail
      // Fazer um log ..
    }
  }
}
