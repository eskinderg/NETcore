using System.Collections.Generic;
using System.Linq;
using Project.Data;
using Project.Model.Models;

namespace Project.Services
{
  public class CategoryService : ICategoryService
  {
    public IRepository<Category> Repository { get; }

    public CategoryService(IRepository<Category> repository) => Repository = repository;

    public IEnumerable<Category> AllCategories => Repository.Table.ToList();
  }
}
