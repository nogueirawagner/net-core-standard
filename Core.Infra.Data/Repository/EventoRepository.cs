using Core.Domain.Models.Eventos;
using Core.Infra.Data.Context;
using Eventos.IO.Domain.Eventos.Repository;
using System;
using System.Collections.Generic;

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
      throw new NotImplementedException();
    }

    public void AtualizarEndereco(Endereco endereco)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Categoria> ObterCategorias()
    {
      throw new NotImplementedException();
    }

    public Endereco ObterEnderecoPorId(Guid id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId)
    {
      throw new NotImplementedException();
    }
  }
}
