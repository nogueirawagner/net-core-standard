using Core.Domain.Core.Notifications;
using Core.Domain.Interfaces;
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

    public Guid OrganizadorId { get; set; }

    public BaseController(IDomainNotificationHandler<DomainNotification> notifications, IUser user)
    {
      _user = user;
      _notifications = notifications;

      if (_user.IsAuthenticated())
        OrganizadorId = _user.GetUserId();
    }

    protected bool OperacaoValida()
    {
      return (!_notifications.HasNotifications());
    }
  }
}
