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

    public void Insert(T entity)
    {
      if (entity == null)
        throw new ArgumentNullException("entity");

      Entities.Add(entity);
    }

    public void Insert(IEnumerable<T> entities)
    {
      if (entities == null)
        throw new ArgumentNullException("entities");

      foreach (var entity in entities)
        Entities.Add(entity);
    }

    public void Update(T entity)
    {
      if (entity == null)
        throw new ArgumentNullException("entity");
      Entities.Update(entity);
    }

    public void Update(IEnumerable<T> entities)
    {
      if (entities == null)
        throw new ArgumentNullException("entities");
    }

    public void Delete(T entity)
    {
      if (entity == null)
        throw new ArgumentNullException("entity");

      Entities.Remove(entity);
    }

    public void Delete(IEnumerable<T> entities)
    {
      if (entities == null)
        throw new ArgumentNullException("entities");

      foreach (var entity in entities)
        Entities.Remove(entity);
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

  }

}
