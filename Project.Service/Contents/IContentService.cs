using System.Collections.Generic;
using Project.Model.Models;

namespace Project.Services
{
    public interface IContentService
    {
        IEnumerable<Content> GetAllContents();

        Content GetContent(int id);

        Content AddContent(Content content);
    }
}
