using Core.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Organizadores.Events
{
  public class BaseOrganizadorEvent : Event
  {
    public Guid Id { get; protected set; }
    public string Nome { get; protected set; }
    public string CPF { get; protected set; }
    public string Email { get; protected set; }
  }
}
