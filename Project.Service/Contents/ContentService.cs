using System.Collections.Generic;
using System.Linq;
using Project.Model.Models;
using Project.Data;
using Microsoft.EntityFrameworkCore;

namespace Project.Services
{
  public class ContentService : IContentService
  {
    public IRepository<Content> Repository { get; }

    public ContentService(IRepository<Content> contentRepository) => Repository = contentRepository;

    public IEnumerable<Content> AllContents => Repository.Table.Include(c => c.Folder);

    public Content GetContent(int id) => Repository.Table.Where(c => c.Id == id).
      Include(c => c.Folder).FirstOrDefault();

    public Content AddContent(Content content)
    {
      Repository.Insert(content);
      return content;
    }
  }
}
