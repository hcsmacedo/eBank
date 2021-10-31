using eBank.Domain.Interfaces.Repositories;
using eBank.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBank.Infra.Repository
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DatabaseContext _context;

        public RepositoryBase(DatabaseContext Context)
        {
            _context = Context;
        }

        public async Task<bool> Add(TEntity obj)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<bool> Update(TEntity obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                var obj = await _context.Set<TEntity>().FindAsync(id);
                _context.Set<TEntity>().Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
