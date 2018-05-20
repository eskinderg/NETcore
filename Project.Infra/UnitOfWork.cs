using System;
using Project.Data;
using Project.Services;

namespace Project.Infra
{
    public class UnitOfWork: IUnitOfWork
    {
        public AppDbContext Context { get; }
        public ICategoryService Categories { get; private set; }
        public IFolderService Folders { get; private set; }
        public IContentService Contents { get; private set; }


        public UnitOfWork(
            IContentService contents,
            IFolderService folders,
            ICategoryService categories,
            AppDbContext context )
        {
            Context = context;

            Categories = categories;
            Folders = folders;
            Contents = contents;
        }

        public int Save() => Context.SaveChanges();

        public void Dispose() => Context.Dispose();
    }
}
