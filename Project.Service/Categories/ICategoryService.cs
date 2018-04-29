using System.Collections.Generic;
using Project.Model.Models;

namespace Project.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
    }
}
