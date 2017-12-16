using System;

namespace Core.Domain.Core.Events
{
  public abstract class Message
  {
    protected Message()
    {
      MessageType = GetType().Name;
    }

    public string MessageType { get; protected set; }
    public Guid AggregateId { get; set; }
  }
}
