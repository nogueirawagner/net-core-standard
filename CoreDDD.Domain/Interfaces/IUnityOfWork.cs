using System;

namespace Core.Domain.Interfaces
{
  public interface IUnityOfWork : IDisposable
  {
    CommandResponse Commit();

  }
}
