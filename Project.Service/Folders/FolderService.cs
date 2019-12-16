using System.Collections.Generic;
using System.Linq;
using Project.Model.Models;
using Project.Data;

namespace Project.Services
{
  public class FolderService : IFolderService
  {
    public IRepository<Folder> FolderRepository { get; }

    public FolderService(IRepository<Folder> folderRepository) => FolderRepository = folderRepository;

    public IEnumerable<Folder> GetAllFolders() => FolderRepository.Table.ToList();

    public Folder GetFolder(string name) => FolderRepository.Table.FirstOrDefault(f => f.Name == name);

    public Folder GetFolder(int id) => FolderRepository.GetById(id);

    public IEnumerable<Folder> RootFolders
    {
      get
      {
        return FolderRepository.Table.Where(f => f.Name == null).ToList();
      }
    }
  }
}
