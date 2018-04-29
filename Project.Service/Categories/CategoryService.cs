using System.Collections.Generic;
using System.Linq;
using Project.Data;
using Project.Model.Models;

namespace Project.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.Table.ToList();
        }
    }
}
