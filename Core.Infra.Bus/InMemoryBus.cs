using Core.Domain.Core.Bus;
using Core.Domain.Core.Commands;
using Core.Domain.Core.Events;
using Core.Domain.Core.Notifications;
using System;

namespace Core.Infra.Bus
{
  public sealed class InMemoryBus : IBus
  {
    // método de acesso ao conteiner de injeção de dependencia.
    public static Func<IServiceProvider> ContainerAccessor { get; set; }
    private static IServiceProvider Container => ContainerAccessor();

    public void RaiseEvent<T>(T theEvent) where T : Event
    {
      Publish(theEvent);
    }

    public void SendCommand<T>(T theCommand) where T : Command
    {
      Publish(theCommand);
    }

    private static void Publish<T>(T message) where T : Message
    {
      if (Container == null) return;

      var obj = Container.GetService(message.MessageType.Equals("DomainNotification") 
        ? typeof(IDomainNotificationHandler<T>)
        : typeof(IHandler<T>));

      ((IHandler<T>)obj).Handle(message);
    }
  }
}
