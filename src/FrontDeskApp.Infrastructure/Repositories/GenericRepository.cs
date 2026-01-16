using System.Linq.Expressions;
using FrontDeskApp.Application.Common.Pagination;
using FrontDeskApp.Application.RepositoryInterfaces;
using FrontDeskApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrontDeskApp.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        protected readonly FrontDeskAppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(FrontDeskAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id, bool asNoTracking = false)
        {
            if (asNoTracking)
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false)
        {
            return asNoTracking
                ? await _dbSet.AsNoTracking().ToListAsync()
                : await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false)
        {
            return asNoTracking
                ? await _dbSet.AsNoTracking().Where(predicate).ToListAsync()
                : await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync(); // auto-save
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync(); // auto-save
        }
        public void Remove(T entity) => _dbSet.Remove(entity);

        public async Task<PagedResult<T>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            string? sortBy,
            bool sortDescending = false,
            bool asNoTracking = true)
        {
            IQueryable<T> query = _dbSet;

            if (asNoTracking)
                query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                query = sortDescending
                    ? query.OrderByDescending(e => EF.Property<object>(e, sortBy))
                    : query.OrderBy(e => EF.Property<object>(e, sortBy));
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        
    }
}