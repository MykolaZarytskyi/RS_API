using System.Collections.Generic;
using System.Threading.Tasks;

namespace RS_API.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(int id);
        void Update(TEntity item);
        void Add(TEntity item);
        Task<bool> SaveAsync();
    }
}
