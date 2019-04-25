using System.Collections.Generic;
using Project.Model.Models;

namespace Project.Services
{
    public interface IFolderService
    {
        IEnumerable<Folder> GetAllFolders();

        Folder GetFolder(string name);

        Folder GetFolder(int id);

        IEnumerable<Folder> RootFolders { get; }

    }
}
