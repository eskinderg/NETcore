using System.Collections.Generic;
using Project.Model.Models;

namespace Project.Services
{
  public interface ICategoryService : IService<Category>
  {
    IEnumerable<Category> AllCategories { get; }
  }
}
