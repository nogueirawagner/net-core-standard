using Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Domain.Interfaces
{
  public interface IRepository<TEntity> where TEntity : Entity<TEntity>
  {
    void Adicionar(TEntity obj);
    void Atualizar(TEntity obj);
    TEntity PegarPorId(Guid id);
    IEnumerable<TEntity> PegarTodos();
    IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
    void Remover(Guid id);
    int SaveChanges();
    void Dispose();
  }
}
  

