using Core.Domain.CommandHandlers;
using Core.Domain.Core.Events;
using Core.Domain.Eventos.Commands;
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

    public EventoCommandHandler(IEventoRepository eventoRepository, IUnitOfWork uow)
      :base(uow)
    {
      _eventoRepository = eventoRepository;
    }
    
    private readonly IEventoRepository _eventoRepository;

    public void Handle(RegistrarEventoCommand message)
    {
      var evento = new Evento(message.Nome, message.Descricao, message.DataInicio, message.DataFim, 
        message.Gratuito, message.Valor, message.Online, message.NomeEmpresa);

      if(!evento.EhValido())
      {
        NotificarValidacoesErro(evento.ValidationResult);
        return;
      }

      // TODO:
      // Validações de negócio
          // Organizador por registrar evento?


      // Persistencia


      _eventoRepository.Adicionar(evento);

      if (Commit())
      {
        // Notificar processo concluído!
      }
    }

    public void Handle(ExcluirEventoCommand message)
    {
      
    }

    public void Handle(AtualizarEventoCommand message)
    {
      throw new NotImplementedException();
    }
  }
}
