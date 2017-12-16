using Core.Domain.Interfaces;
using Core.Domain.Models;
using Core.Infra.Data.Context;

namespace Core.Infra.Data.Repository
{
  public class EventoRepository : Repository<Evento>, IEventoRepository
  {
    public EventoRepository(CoreContext db) 
      : base(db)
    {
    }

    public void AdicionarEndereco(Endereco endereco)
    {
      Db.Enderecos.Add(endereco);
    }

    public void AtualizarEndereco(Endereco endereco)
    {
      Db.Enderecos.Update(endereco);
    }
  }
}
