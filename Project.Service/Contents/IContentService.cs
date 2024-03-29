﻿using System.Collections.Generic;
using Project.Model.Models;

namespace Project.Services
{
  public interface IContentService : IService<Content>
  {
    IEnumerable<Content> AllContents { get; }

    Content GetContent(int id);

    Content AddContent(Content content);
  }
}
