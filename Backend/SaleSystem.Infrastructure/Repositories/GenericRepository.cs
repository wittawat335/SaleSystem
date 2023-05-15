using Microsoft.EntityFrameworkCore;
using SaleSystem.Core.Domain.RepositoryContracts;
using SaleSystem.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SaleSystem.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SaleSystemDbContext _dbContext;

        public GenericRepository(SaleSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                T? result = await _dbContext.Set<T>().FirstOrDefaultAsync(filter);
                return result;
            }
            catch { 
                throw; 
            }
        }
        public async Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>>? filter, int? skip, int? take)
        {
            try
            {
                IQueryable<T> queryModel = filter == null ? _dbContext.Set<T>() : _dbContext.Set<T>().Where(filter);
                if (skip != null)
                    queryModel = queryModel.Skip(skip.Value);
                if (take != null)
                    queryModel = queryModel.Take(take.Value);

                return queryModel;
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> InsertAsync(T model)
        {
            try
            {
                _dbContext.Set<T>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateAsync(T model)
        {
            try
            {
                _dbContext.Set<T>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch{
                throw;
            }
        }
        public async Task<bool> DeleteAsync(T model)
        {
            try
            {
                _dbContext.Set<T>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch{
                throw;
            }
        }

        public async Task<IQueryable<T>> GetList(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                IQueryable<T> queryModel = filter == null ? _dbContext.Set<T>() : _dbContext.Set<T>().Where(filter);
                return queryModel;
            }
            catch { throw; }
        }
    }
}
