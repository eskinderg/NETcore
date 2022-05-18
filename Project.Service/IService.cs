using Project.Data;
using Project.Model;

namespace Project.Services
{
  public interface IService<T> where T : BaseEntity
  {
    IRepository<T> Repository { get; }
  }
}
