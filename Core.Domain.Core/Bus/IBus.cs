using Core.Domain.Core.Commands;
using Core.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Core.Bus
{
  public interface IBus
  {
    // Um comando é sempre enviado
    void SendCommand<T>(T theCommand) where T : Command;

    // Um evento é sempre lançado
    void RaiseEvent<T>(T theEvent) where T : Event;
  }
}
