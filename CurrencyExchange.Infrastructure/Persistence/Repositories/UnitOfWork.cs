using CurrencyExchange.Core.Entities;
using CurrencyExchange.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context) => (_context)= (context);

        public IRepository<TEntity> repository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_context);
        }

        public void Dispose()=> _context.Dispose();


        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

     
    }
}
