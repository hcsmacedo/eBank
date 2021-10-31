using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBank.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<bool> Add(TEntity obj);

        Task<TEntity> GetById(int id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<bool> Update(TEntity obj);

        Task<bool> Remove(int id);

        void Dispose();
    }
}