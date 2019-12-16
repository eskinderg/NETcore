using System.Collections.Generic;
using System.Linq;
using Project.Data;
using Project.Model.Models;

namespace Project.Services
{
  public class CategoryService : ICategoryService
  {
    public IRepository<Category> CategoryRepository { get; }

    public CategoryService(IRepository<Category> categoryRepository) => CategoryRepository = categoryRepository;

    public IEnumerable<Category> AllCategories => CategoryRepository.Table.ToList();
  }
}
