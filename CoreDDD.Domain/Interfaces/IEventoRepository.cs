using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Domain.Models;

namespace Core.Domain.Interfaces
{
  public interface IEventoRepository : IRepository<Evento>
  {
    void AdicionarEndereco(Endereco endereco);
    void AtualizarEndereco(Endereco endereco);
  }
}
