using System.Collections.Generic;
using System.Linq;
using Project.Model.Models;
using Project.Data;

namespace Project.Services
{
  public class FolderService : IFolderService
  {
    public IRepository<Folder> Repository { get; }

    public FolderService(IRepository<Folder> repository) => Repository = repository;

    public IEnumerable<Folder> GetAllFolders() => Repository.Table.ToList();

    public Folder GetFolder(string name) => Repository.Table.FirstOrDefault(f => f.Name == name);

    public Folder GetFolder(int id) => Repository.GetById(id);

    public IEnumerable<Folder> RootFolders
    {
      get
      {
        return Repository.Table.Where(f => f.Name == null).ToList();
      }
    }
  }
}
