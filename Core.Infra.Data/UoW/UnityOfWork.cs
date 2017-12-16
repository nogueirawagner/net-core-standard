using Core.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infra.Data.UoW
{
  public class UnityOfWork
  {
    private readonly CoreContext _context;

    public UnityOfWork(CoreContext context)
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
