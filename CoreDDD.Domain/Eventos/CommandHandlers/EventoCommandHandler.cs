using Core.Domain.CommandHandlers;
using Core.Domain.Core.Bus;
using Core.Domain.Core.Events;
using Core.Domain.Core.Notifications;
using Core.Domain.Eventos.Commands;
using Core.Domain.Eventos.Events;
using Core.Domain.Models.Eventos;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Eventos.CommandHandlers
{
  public class EventoCommandHandler : CommandHandler,
    IHandler<RegistrarEventoCommand>,
    IHandler<AtualizarEventoCommand>,
    IHandler<ExcluirEventoCommand>
  {

    private readonly IEventoRepository _eventoRepository;
    private readonly IBus _bus;
    private readonly IDomainNotificationHandler<DomainNotification> _notifications;

    public EventoCommandHandler(
      IEventoRepository eventoRepository, 
      IUnitOfWork uow, 
      IBus bus, 
      IDomainNotificationHandler<DomainNotification> notifications)
      : base(uow, bus, notifications)
    {
      _eventoRepository = eventoRepository;
      _bus = bus;
      _notifications = notifications;
    }

    public void Handle(RegistrarEventoCommand message)
    {
      var evento = new Evento(message.Nome, message.Descricao, message.DataInicio, message.DataFim,
        message.Gratuito, message.Valor, message.Online, message.NomeEmpresa);

      if (!evento.EhValido())
      {
        NotificarValidacoesErro(evento.ValidationResult);
        return;
      }

      // TODO:
      // Validações de negócio
      // Organizador por registrar evento?

      _eventoRepository.Adicionar(evento);

      if (Commit())
        _bus.RaiseEvent(new EventoRegistradoEvent(evento.Id, evento.Nome, evento.DataInicio, evento.DataFim, evento.Gratuito, evento.Valor, evento.Online, evento.NomeEmpresa));
    }

    public void Handle(ExcluirEventoCommand message)
    {
      _eventoRepository.Remover(message.Id);
      _bus.RaiseEvent(new EventoExcluidoEvent(message.Id));
    }

    public void Handle(AtualizarEventoCommand message)
    {
      //var evento = new Evento(message.Nome, message.Descricao, message.DataInicio, message.DataFim,
      // message.Gratuito, message.Valor, message.Online, message.NomeEmpresa);

      //_eventoRepository.Atualizar(evento);

      //_bus.RaiseEvent(new EventoAtualizadoEvent(evento.Id, ))
    }
  }
}
