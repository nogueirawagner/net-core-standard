using Core.Domain.Interfaces;
using Core.Domain.Models.Eventos;
using System;
using System.Collections.Generic;

namespace Core.Domain.Eventos.Repository
{
  public interface IEventoRepository : IRepository<Evento>
  {
    IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId);
    Endereco ObterEnderecoPorId(Guid id);
    void AdicionarEndereco(Endereco endereco);
    void AtualizarEndereco(Endereco endereco);
    IEnumerable<Categoria> ObterCategorias();
  }
}