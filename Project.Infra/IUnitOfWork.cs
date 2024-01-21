using System;
using Project.Data;
using Project.Services;

namespace Project.Infra
{
  public interface IUnitOfWork : IDisposable
  {
    ICategoryService Categories { get; }
    IFolderService   Folders    { get; }
    IContentService  Contents   { get; }
    IEventService    Events     { get; }
    INoteService     Notes      { get; }
    int              Save();
    AppDbContext     AppDbContext {get;}
  }
}
