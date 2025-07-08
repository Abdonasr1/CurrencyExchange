using CurrencyExchange.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> repository<T>() where T : class;
        Task<int> SaveChangesAsync();
    }
}
