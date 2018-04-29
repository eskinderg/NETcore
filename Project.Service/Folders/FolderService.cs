using System.Collections.Generic;
using System.Linq;
using Project.Model.Models;
using Project.Data;

namespace Project.Services
{
    public class FolderService : IFolderService
    {
        private readonly IRepository<Folder> _folderRepository;

        public FolderService(IRepository<Folder> folderRepository)
        {
            _folderRepository = folderRepository;
        }

        public IEnumerable<Folder> GetAllFolders()
        {
            return new List<Folder> { new Folder{ Name="Myname", Id = 2}};
            // return _folderRepository.Table.ToList();
        }

        public Folder GetFolder(string name)
        {
            return _folderRepository.Table.FirstOrDefault(f => f.Name == name);
        }

        public Folder GetFolder(int id)
        {
            return _folderRepository.GetById(id);
        }

        public IEnumerable<Folder> RootFolders
        {
            get
            {
                return _folderRepository.Table.Where(f => f.Name == null).ToList();
            }
        }
    }
}
