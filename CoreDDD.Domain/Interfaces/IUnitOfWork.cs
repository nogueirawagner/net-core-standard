using Core.Domain.Core.Commands;
using System;

namespace Core.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}