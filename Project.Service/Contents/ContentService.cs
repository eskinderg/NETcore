using System.Collections.Generic;
using System.Linq;
using Project.Model.Models;
using Project.Data;
using Microsoft.EntityFrameworkCore;

namespace Project.Services
{
    public class ContentService : IContentService
    {
        private readonly IRepository<Content> _contentRepository;

        public ContentService(IRepository<Content> contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public IEnumerable<Content> GetAllContents()
        {
            return _contentRepository.Table.Include(c => c.Folder);
        }

        public Content GetContent(int id)
        {
            return _contentRepository.Table.Where(c => c.Id == id).
                                        Include(c => c.Folder).FirstOrDefault();
        }

        public Content AddContent(Content content)
        {
            _contentRepository.Insert(content);
            return content;
        }
    }
}
