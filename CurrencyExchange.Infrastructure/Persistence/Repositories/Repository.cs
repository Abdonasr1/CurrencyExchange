using CurrencyExchange.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter = null!, bool tracked = true)
        {
            var query = _dbSet.AsQueryable();

            if (filter is not null)
                query = query.Where(filter);

            if (!tracked)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null!, bool tracked = true)
        {
            var query = _dbSet.AsQueryable();

            if (filter is not null)
                query = query.Where(filter);

            if (!tracked)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task RemoveAsync(T team)
        {
            _context.Remove(team);
        }

        
    }
}
