using Core.Domain.Core.Events;

namespace Core.Domain.Eventos.Events
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
