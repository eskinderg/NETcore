using System;
using System.Collections.Generic;
using System.Linq;
using Project.Model;

namespace Project.Data
{
  public interface IRepository<T> : IDisposable where T : BaseEntity
  {

    T GetById(params object[] id);

    T Insert(T entity);

    IEnumerable<T> Insert(IEnumerable<T> entities);

    T Update(T entity);

    IEnumerable<T> Update(IEnumerable<T> entities);

    T Delete(T entity);

    IEnumerable<T> Delete(IEnumerable<T> entities);

    IQueryable<T> Table { get; }

    IQueryable<T> TableNoTracking { get; }
  }

}
