using Core.Domain.Core.Commands;
using Core.Infra.Data.Context;
using Eventos.IO.Domain.Interfaces;

namespace Core.Infra.Data.UoW
{
  public class UnitOfWork : IUnitOfWork
    {
        private readonly CoreContext _context;

        public UnitOfWork(CoreContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    CommandResponse IUnitOfWork.Commit()
    {
      throw new System.NotImplementedException();
    }
  }
}