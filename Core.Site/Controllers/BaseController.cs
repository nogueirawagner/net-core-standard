using Core.Domain.Core.Bus;
using Core.Domain.Core.Notifications;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Site.Controllers
{
  public class BaseController : Controller
  {
    private readonly IDomainNotificationHandler<DomainNotification> _notifications;
    private readonly IUser _user;
    private readonly IBus _bus;

    public Guid OrganizadorId { get; set; }

    public BaseController(IDomainNotificationHandler<DomainNotification> notifications, IUser user, IBus bus)
    {
      _user = user;
      _notifications = notifications;
      _bus = bus;

      if (_user.IsAuthenticated())
        OrganizadorId = _user.GetUserId();
    }

    protected bool OperacaoValida()
    {
      return (!_notifications.HasNotifications());
    }

    protected void NotificarErroModelInvalida()
    {
      var erros = ModelState.Values.SelectMany(s => s.Errors);
      foreach (var erro in erros)
      {
        NotificarErro("", erro.ErrorMessage);
      }
    }

    protected void NotificarErro(string codigo, string mensagem)
    {
      _bus.RaiseEvent(new DomainNotification(codigo, mensagem));
    }

    protected void AdicionaErrosIdentity(IdentityResult result)
    {
      foreach (var error in result.Errors)
      {
        NotificarErro(result.ToString(), error.Description);
      }
    }
  }
}
