using System.Linq.Expressions;

namespace SaleSystem.Core.Domain.RepositoryContracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>>? filter = null, int? skip = null, int? take = null);
        Task<IQueryable<T>> GetList(Expression<Func<T, bool>> filter = null);
        Task<T> InsertAsync(T model);
        Task<bool> UpdateAsync(T model);
        Task<bool> DeleteAsync(T model);
    }
}
