using System;
using Project.Services;

namespace Project.Infra
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryService Categories { get; }
        IFolderService Folders { get;  }
        IContentService Contents { get; }
        int Save();
    }
}
