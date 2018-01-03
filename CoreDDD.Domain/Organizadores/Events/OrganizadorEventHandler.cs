using Core.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Organizadores.Events
{
  public class OrganizadorEventHandler :
    IHandler<OrganizadorRegistradoEvent>
  {
    public void Handle(OrganizadorRegistradoEvent message)
    {
      // TODO:
      // Envia um email...
      // Faz um log...
    }
  }
}
