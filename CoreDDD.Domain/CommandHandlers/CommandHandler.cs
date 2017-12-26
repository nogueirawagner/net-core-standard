using Core.Domain.Core.Bus;
using Core.Domain.Core.Notifications;
using Eventos.IO.Domain.Interfaces;
using FluentValidation.Results;

namespace Core.Domain.CommandHandlers
{
  public abstract class CommandHandler
  {
    private readonly IUnitOfWork _uow;
    private readonly IBus _bus;
    private readonly IDomainNotificationHandler<DomainNotification> _notifications;

    public CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
    {
      _uow = uow;
      _bus = bus;
      _notifications = notifications;
    }

    protected void NotificarValidacoesErro(ValidationResult validationResult)
    {
      foreach(var erro in validationResult.Errors)
      {
        var error = erro.ErrorMessage;
        _bus.RaiseEvent(new DomainNotification(erro.PropertyName, erro.ErrorMessage));
      }
    }

    protected bool Commit()
    {
      if (_notifications.HasNotifications()) return false;
      var cmdResponse = _uow.Commit();
      if (cmdResponse.Success)
        return true;
      else
      {
        _bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um erro ao salvar os dados no banco."));
        return false;
      }
        
    }
  }
}
