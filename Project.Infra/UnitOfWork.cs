using Project.Data;
using Project.Services;

namespace Project.Infra
{
  public class UnitOfWork: IUnitOfWork
  {
    protected AppDbContext     Context    { get; }
    public    ICategoryService Categories { get; private set; }
    public    IFolderService   Folders    { get; private set; }
    public    IContentService  Contents   { get; private set; }
    public    IEventService    Events     { get; private set; }
    public    INoteService     Notes      { get; private set; }
    public AppDbContext AppDbContext {get; private set; }

    public UnitOfWork(
        IContentService  contents,
        IFolderService   folders,
        ICategoryService categories,
        IEventService    events,
        INoteService     notes,
        AppDbContext     _context
        )
    {
      Categories = categories;
      Folders    = folders;
      Contents   = contents;
      Events     = events;
      Notes      = notes;
      AppDbContext = _context;
    }

    public int Save()     => AppDbContext.SaveChanges();
    public void Dispose() => AppDbContext.Dispose();
  }
}
