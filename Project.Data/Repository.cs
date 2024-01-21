using System;
using System.Linq;
using Project.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project.Data
{
  public class Repository<T> : IRepository<T> where T : BaseEntity
  {
    public AppDbContext Context { get; }
    private DbSet<T> _entities;

    public Repository(AppDbContext context) => Context = context;

    public T GetById(params object[] id) => Entities.Find(id);

    public T Insert(T entity)
    {
      if (entity == null)
        throw new ArgumentNullException("entity");

      return Entities.Add(entity).Entity;
    }

    public IEnumerable<T> Insert(IEnumerable<T> entities)
    {
      if (entities == null)
        throw new ArgumentNullException("entities");

      // foreach (var entity in entities)
        Entities.AddRange(entities);
        return entities;
    }

    public T Update(T entity)
    {
      if (entity == null)
        throw new ArgumentNullException("entity");
      return Entities.Update(entity).Entity;
    }

    public IEnumerable<T> Update(IEnumerable<T> entities)
    {
      if (entities == null)
        throw new ArgumentNullException("entities");
      Entities.UpdateRange(entities);
      return entities;
    }

    public T Delete(T entity)
    {
      if (entity == null)
        throw new ArgumentNullException("entity");

      return Entities.Remove(entity).Entity;
    }

    public IEnumerable<T> Delete(IEnumerable<T> entities)
    {
      if (entities == null)
        throw new ArgumentNullException("entities");

      /* foreach (var entity in entities) */
      Entities.RemoveRange(entities);
      return entities;
    }

    public IQueryable<T> Table
    {
      get { return Entities; }
    }

    public IQueryable<T> TableNoTracking
    {
      get { return Entities.AsNoTracking(); }
    }

    private DbSet<T> Entities
    {
      get { return _entities ?? (_entities = Context.Set<T>()); }
    }

    public void Dispose()
    {
      Context?.Dispose();
    }

  }

}
