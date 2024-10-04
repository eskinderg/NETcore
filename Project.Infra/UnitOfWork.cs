using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Project.Data;
using Project.Services;

namespace Project.Infra
{
  public class UnitOfWork: IUnitOfWork
  {
    protected AppDbContext     Context      { get; }
    public    ICategoryService Categories   { get; private set; }
    public    IFolderService   Folders      { get; private set; }
    public    IContentService  Contents     { get; private set; }
    public    IEventService    Events       { get; private set; }
    public    INoteService     Notes        { get; private set; }
    public    AppDbContext     AppDbContext { get; private set; }

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

    public int Save() {
      try {
        return AppDbContext.SaveChanges();
      }catch(DbUpdateException ex) when (((MySqlException)ex.InnerException).Number == 12121) {
        throw new DbUpdateConflictException(((MySqlException)ex.InnerException).Message);
      } catch(DbUpdateException ex) when (((MySqlException)ex.InnerException).Number == 13131) {
        throw new NoteNotFoundException(((MySqlException)ex.InnerException).Message);
      }
    }

    public void Dispose() => AppDbContext.Dispose();
  }
}
