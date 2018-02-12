using Core.Domain.CommandHandlers;
using Core.Domain.Core.Bus;
using Core.Domain.Core.Events;
using Core.Domain.Core.Notifications;
using Core.Domain.Eventos.Events;
using Core.Domain.Models.Eventos;
using Core.Domain.Eventos.Repository;
using Core.Domain.Interfaces;
using System;

namespace Core.Domain.Eventos.Commands
{
  public class EventoCommandHandler : CommandHandler,
    IHandler<RegistrarEventoCommand>,
    IHandler<AtualizarEventoCommand>,
    IHandler<ExcluirEventoCommand>,
    IHandler<IncluirEnderecoCommand>,
    IHandler<AtualizarEnderecoCommand>
  {

    private readonly IEventoRepository _eventoRepository;
    private readonly IBus _bus;
    private readonly IDomainNotificationHandler<DomainNotification> _notifications;
    private readonly IUser _user;

    public EventoCommandHandler(
      IEventoRepository eventoRepository,
      IUnitOfWork uow,
      IBus bus,
      IDomainNotificationHandler<DomainNotification> notifications,
      IUser user)
      : base(uow, bus, notifications)
    {
      _eventoRepository = eventoRepository;
      _bus = bus;
      _notifications = notifications;
      _user = user;
    }

    public void Handle(RegistrarEventoCommand message)
    {
      var endereco = new Endereco(message.Endereco.Id, message.Endereco.Logradouro, message.Endereco.Numero, message.Endereco.Bairro, message.Endereco.CEP, message.Endereco.Complemento, message.Endereco.Cidade, message.Endereco.Estado, message.Endereco.EventoId.Value);
      var evento = Evento.EventoFactory.NovoEventoCompleto(
          message.Id, message.Nome, message.Descricao,
          message.DescricaoCurta, message.DataInicio, message.DataFim, message.Gratuito,
          message.Valor, message.Online, message.NomeEmpresa, message.OrganizadorId, endereco, message.CategoriaId);

      if (!EventoValido(evento)) return;

      // TODO:
      // Validações de negócio
      // Organizador por registrar evento?

      _eventoRepository.Adicionar(evento);

      if (Commit())
        _bus.RaiseEvent(new EventoRegistradoEvent(evento.Id, evento.Nome, evento.DataInicio, evento.DataFim, evento.Gratuito, evento.Valor, evento.Online, evento.NomeEmpresa));
    }

    public void Handle(ExcluirEventoCommand message)
    {
      if (!EventoExiste(message.Id, message.MessageType)) return;

      var eventoAtual = _eventoRepository.ObterPorId(message.Id);
      eventoAtual.ExcluirEvento();

      _eventoRepository.Atualizar(eventoAtual);
      if (Commit())
        _bus.RaiseEvent(new EventoExcluidoEvent(message.Id));
    }

    public void Handle(AtualizarEventoCommand message)
    {
      if (!EventoExiste(message.Id, message.MessageType)) return;

      var eventoAtual = _eventoRepository.ObterPorId(message.Id);

      if(eventoAtual.OrganizadorId  != message.OrganizadorId)
      {
        _bus.RaiseEvent(new DomainNotification(message.MessageType, "Evento não pertence ao organizador"));
        return;
      }

      var evento = Evento.EventoFactory.NovoEventoCompleto(
          message.Id, message.Nome, message.Descricao,
          message.DescricaoCurta, message.DataInicio, message.DataFim, message.Gratuito,
          message.Valor, message.Online, message.NomeEmpresa, message.OrganizadorId, eventoAtual.Endereco, message.CategoriaId);

      if (!evento.Online && evento.Endereco == null)
      {
        _bus.RaiseEvent(new DomainNotification(message.MessageType, "Não é possível atualizar um evento sem informar um endereço"));
        return;
      }

      if (!EventoValido(evento)) return;

      _eventoRepository.Atualizar(evento);
      if (Commit())
      {
        _bus.RaiseEvent(new EventoAtualizadoEvent(
          evento.Id, evento.Nome, evento.Descricao, evento.DescricaoCurta,
          evento.DataInicio, evento.DataFim, evento.Gratuito, evento.Valor,
          evento.Online, evento.NomeEmpresa));
      }
    }

    private bool EventoValido(Evento evento)
    {
      if (evento.EhValido()) return true;

      NotificarValidacoesErro(evento.ValidationResult);
      return false;
    }

    private bool EventoExiste(Guid id, string messageType)
    {
      var evento = _eventoRepository.ObterPorId(id);
      if (evento != null) return true;

      _bus.RaiseEvent(new DomainNotification(messageType, "Evento não encontrado."));
      return false;
    }

    public void Handle(IncluirEnderecoCommand message)
    {
      var endereco = new Endereco(message.Id, message.Logradouro, message.Numero, message.Bairro, message.CEP, message.Complemento, message.Cidade, message.Estado, message.EventoId.Value);

      if (!endereco.EhValido())
      {
        NotificarValidacoesErro(endereco.ValidationResult);
        return;
      }

      _eventoRepository.AdicionarEndereco(endereco);
      if (Commit())
      {
        _bus.RaiseEvent(new EnderecoAdicionadoEvent(endereco.Id, endereco.Logradouro, endereco.Numero, endereco.Bairro, endereco.CEP, endereco.Complemento, endereco.Cidade, endereco.Estado, endereco.EventoId.Value));
      }
    }

    public void Handle(AtualizarEnderecoCommand message)
    {
      var endereco = new Endereco(message.Id, message.Logradouro, message.Numero, message.Bairro, message.CEP, message.Complemento, message.Cidade, message.Estado, message.EventoId.Value);

      if (!endereco.EhValido())
      {
        NotificarValidacoesErro(endereco.ValidationResult);
        return;
      }

      _eventoRepository.AtualizarEndereco(endereco);
      if (Commit())
      {
        _bus.RaiseEvent(new EnderecoAtualizadoEvent(endereco.Id, endereco.Logradouro, endereco.Numero, endereco.Bairro, endereco.CEP, endereco.Complemento, endereco.Cidade, endereco.Estado, endereco.EventoId.Value));
      }
    }
  }
}
