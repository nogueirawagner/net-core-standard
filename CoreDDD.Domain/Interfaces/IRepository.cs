using Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Domain.Interfaces
{
  public interface IRepository<TEntity> where TEntity : Entity<TEntity>
  {
    void Adicionar(TEntity obj);

    void Atualizar(TEntity obj);

    IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

    TEntity PegarPorId(Guid id);

    IEnumerable<TEntity> PegarTodos();

    void Remover(Guid id);

    int SaveChanges();

    void Dispose();
  }
}
  

