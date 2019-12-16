using System.Collections.Generic;
using System.Linq;
using Project.Model.Models;
using Project.Data;
using Microsoft.EntityFrameworkCore;

namespace Project.Services
{
  public class ContentService : IContentService
  {
    public IRepository<Content> ContentRepository { get; }

    public ContentService(IRepository<Content> contentRepository) => ContentRepository = contentRepository;

    public IEnumerable<Content> AllContents => ContentRepository.Table.Include(c => c.Folder);

    public Content GetContent(int id) => ContentRepository.Table.Where(c => c.Id == id).
      Include(c => c.Folder).FirstOrDefault();

    public Content AddContent(Content content)
    {
      ContentRepository.Insert(content);
      return content;
    }
  }
}
