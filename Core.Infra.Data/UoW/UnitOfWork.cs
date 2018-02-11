  using Core.Domain.Core.Commands;
using Core.Infra.Data.Context;
using Core.Domain.Interfaces;

namespace Core.Infra.Data.UoW
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly CoreContext _context;

    public UnitOfWork(CoreContext context)
    {
      _context = context;
    }

    public CommandResponse Commit()
    {
      var rowsAffected = _context.SaveChanges();
      return new CommandResponse(rowsAffected > 0);
    }

    public void Dispose()
    {
      _context.Dispose();
    }
  }
}