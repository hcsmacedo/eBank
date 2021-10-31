using System;
using System.Collections.Generic;
using eBank.Domain.Interfaces.Repositories;
using eBank.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace eBank.Domain.Services
{
    public abstract class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        
        public ServiceBase(IRepositoryBase<TEntity> Repository)
        {
            _repository = Repository;
        }
        public async Task<bool> Add(TEntity obj)
        {
            return await _repository.Add(obj);
        }
        public async Task<TEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<bool> Update(TEntity obj)
        {
            return await _repository.Update(obj);
        }
        public async Task<bool> Remove(int id)
        {
            return await _repository.Remove(id);
        }
        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
