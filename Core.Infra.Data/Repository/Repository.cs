using Core.Domain.Core.Models;
using Core.Domain.Interfaces;
using Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Infra.Data.Repository
{
  public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
  {
    protected CoreContext Db;
    protected DbSet<TEntity> DbSet;
    protected DbConnection Connection;

    protected Repository(CoreContext db)
    {
      Db = db;
      DbSet = Db.Set<TEntity>();
      Connection = Db.Database.GetDbConnection();
    }

    public virtual void Adicionar(TEntity obj)
    {
      DbSet.Add(obj);
    }

    public virtual void Atualizar(TEntity obj)
    {
      DbSet.Update(obj);
    }

    public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
    {
      return DbSet.AsNoTracking().Where(predicate);
    }

    public virtual TEntity ObterPorId(Guid id)
    {
      return DbSet.AsNoTracking().FirstOrDefault(s => s.Id == id);
    }

    public virtual IEnumerable<TEntity> ObterTodos()
    {
      return DbSet.ToList();
    }

    public virtual void Remover(Guid id)
    {
      var obj = DbSet.Find(id);
      DbSet.Remove(obj);
    }

    public int SaveChanges()
    {
      return Db.SaveChanges();
    }

    public virtual void Dispose()
    {
      Db.Dispose();
    }
  }
}
