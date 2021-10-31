using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBank.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<bool> Add(TEntity obj);

        Task<TEntity> GetById(int id);
        
        Task<IEnumerable<TEntity>>  GetAll();

        Task<bool> Update(TEntity obj);

        Task<bool> Remove(int id);

        void Dispose();
    }
}
