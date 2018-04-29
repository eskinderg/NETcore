using Project.Model;
using Microsoft.EntityFrameworkCore;

namespace Project.Data
{
    public interface IDbContext
    {

        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        int SaveChanges();

        int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);

    }
}
