using Core.Domain.Core.Bus;
using Core.Domain.Core.Notifications;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Core.Services.Api.Controllers
{
  [Produces("application/json")]
  public abstract class BaseController : Controller
  {
    private readonly IDomainNotificationHandler<DomainNotification> _notifications;
    private readonly IBus _bus;

    protected Guid OrganizadorId { get; set; }

    protected BaseController(
      IDomainNotificationHandler<DomainNotification> notifications,
      IUser user, 
      IBus bus)
    {
      _notifications = notifications;
      _bus = bus;

      if (user.IsAuthenticated())
        OrganizadorId = user.GetUserId();
    }

    protected new IActionResult Response(object result = null)
    {
      if (OperacaoValida())
      {
        return Ok(new
        {
          success = true,
          data = result
        });
      }

      return BadRequest(new
      {
        success = false,
        data = result,
        errors = _notifications.GetNotifications().Select(s => s.Value)
      });
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

