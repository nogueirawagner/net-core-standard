using Core.Domain.Core.Events;
using System;

namespace Core.Domain.Core.Notifications
{
  public class DomainNotification : Event
  {
    public Guid DomainNotificationId { get; set; }
    public string Key { get; set; } // nome do evento
    public string Value { get; set; } // mensagem
    public int Version { get; set; }

    public DomainNotification(string key, string value)
    {
      DomainNotificationId = Guid.NewGuid();
      Key = key;
      Value = value;
      Version = 1;
    }
  }
}
