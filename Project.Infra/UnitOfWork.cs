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
        public IEventService Events { get; private set; }
        public INoteService Notes { get; private set; }

        public UnitOfWork(
            IContentService contents,
            IFolderService folders,
            ICategoryService categories,
            IEventService events,
            INoteService notes,
            AppDbContext context )
        {
            Context = context;

            Categories = categories;
            Folders = folders;
            Contents = contents;
            Events = events;
            Notes = notes;
        }

        public int Save() => Context.SaveChanges();

        public void Dispose() => Context.Dispose();
    }
}
