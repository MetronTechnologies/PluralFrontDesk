using System.Linq.Expressions;
using FrontDeskApp.Application.Common.Pagination;

namespace FrontDeskApp.Application.RepositoryInterfaces
{
    public interface IGenericRepository<T> where T : class
    {
         Task<T?> GetByIdAsync(int id, bool asNoTracking = false);
        Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
        Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        void Remove(T entity);

        Task<PagedResult<T>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            string? sortBy,
            bool sortDescending = false,
            bool asNoTracking = true);
    }
}