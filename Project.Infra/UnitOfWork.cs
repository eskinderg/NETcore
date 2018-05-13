using System;
using Project.Data;
using Project.Services;

namespace Project.Infra
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ProjectDbContext _context;
        public ICategoryService Categories { get; private set; }
        public IFolderService Folders { get; private set; }
        public IContentService Contents { get; private set; }

        public UnitOfWork(
            IContentService contents, 
            IFolderService folders, 
            ICategoryService categories, 
            ProjectDbContext context )
        {
            _context = context;

            Categories = categories;
            Folders = folders;
            Contents = contents;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
