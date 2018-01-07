using Core.Domain.CommandHandlers;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain.Core.Bus;
using Core.Domain.Core.Notifications;
using Core.Domain.Interfaces;
using Core.Domain.Core.Events;
using Core.Domain.Organizadores.Repository;
using Core.Domain.Models.Organizadores;
using Core.Domain.Organizadores.Events;
using System.Linq;

namespace Core.Domain.Organizadores.Commands
{
  public class OrganizadorCommandHandler : CommandHandler,
    IHandler<RegistrarOrganizadorCommand>
  {

    private readonly IOrganizadorRepository _organizadorRepository;
    private readonly IBus _bus;
    private readonly IDomainNotificationHandler<DomainNotification> _notifications;


    public OrganizadorCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IOrganizadorRepository organizadorRepository)
      : base(uow, bus, notifications)
    {
      _organizadorRepository = organizadorRepository;
      _bus = bus;
      _notifications = notifications;
    }

    public void Handle(RegistrarOrganizadorCommand message)
    {
      var organizador = new Organizador(message.Id, message.Nome, message.CPF, message.Email);
      if (!OrganizadorValido(organizador)) return;

      var organizadorExistente = _organizadorRepository.Buscar(s => s.CPF == organizador.CPF || s.Email == organizador.Email);
      if (organizadorExistente.Any())
        _bus.RaiseEvent(new DomainNotification(message.MessageType, "CPF ou Email já cadastrados"));

      _organizadorRepository.Adicionar(organizador);

      if (Commit())
      {
        _bus.RaiseEvent(new OrganizadorRegistradoEvent(organizador.Id, organizador.Nome, organizador.CPF, organizador.Email));
      }
    }

    private bool OrganizadorValido(Organizador organizador)
    {
      if (organizador.EhValido()) return true;

      NotificarValidacoesErro(organizador.ValidationResult);
      return false;
    }
  }
}
