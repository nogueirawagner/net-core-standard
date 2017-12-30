using Core.Domain.Models.Eventos;
using Core.Infra.Data.Context;
using Dapper;
using Core.Domain.Eventos.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Core.Infra.Data.Repository
{
  public class EventoRepository : Repository<Evento>, IEventoRepository
  {
    public EventoRepository(CoreContext db)
      : base(db)
    {
    }

    public override Evento ObterPorId(Guid id)
    {
      var sql =
        @"SELECT * FROM Eventos ev
          LEFT JOIN Enderecos e ON ev.ID = e.ID
          WHERE ev.ID = @pId";

      var evento = Connection.Query<Evento, Endereco, Evento>(sql,
        (e, en) =>
        {
          if (en != null)
            e.AtribuirEndereco(en);
          return e;
        },
        new {pId = id});

      return evento.FirstOrDefault();
    }

    public override IEnumerable<Evento> ObterTodos()
    {
      var sql =
        @"SELECT * FROM Eventos 
          WHERE Excluido = 0";

      return Connection.Query<Evento>(sql);
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
      var sql = @"SELECT * FROM Categorias";
      return Connection.Query<Categoria>(sql);
    }

    public Endereco ObterEnderecoPorId(Guid id)
    {
      var sql = @"SELECT * FROM Enderecos e Where e.Id = @pId";
      var endereco = Connection.Query<Endereco>(sql, new { pId = id });
      return endereco.SingleOrDefault();
    }

    public IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId)
    {
      var sql = @"
                  SELECT * FROM Eventos e 
                  WHERE e.Excluido = 0
                  AND e.OrganizadorId = @pOrganizadorId
                  ORDER BY e.DataFim DESC";

      return Connection.Query<Evento>(sql, new { pOrganizadorId = organizadorId });

    }
  }
}
