using Core.Domain.Models.Organizadores;
using Core.Domain.Organizadores.Repository;
using Core.Infra.Data.Context;

namespace Core.Infra.Data.Repository
{
  public class OrganizadorRepository : Repository<Organizador>, IOrganizadorRepository
  {
    protected OrganizadorRepository(CoreContext db) 
      : base(db)
    {
    }
  }
}
