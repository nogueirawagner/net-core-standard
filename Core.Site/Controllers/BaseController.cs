using Core.Domain.Core.Notifications;
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

    protected bool OperacaoValida()
    {
      return (!_notifications.HasNotifications());
    }


    public BaseController(IDomainNotificationHandler<DomainNotification> notifications)
    {
      _notifications = notifications;
    }

  }
}
