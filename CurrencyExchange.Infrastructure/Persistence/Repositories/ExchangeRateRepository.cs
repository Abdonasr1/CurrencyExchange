using CurrencyExchange.Core.Entities;
using CurrencyExchange.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Persistence.Repositories
{
    public class ExchangeRateRepository : Repository<ExchangeRate>, IRateRepository
    {
        private readonly AppDbContext _context;
        private readonly IRepository<ExchangeRate> _repository;

        public ExchangeRateRepository(AppDbContext context, IRepository<ExchangeRate> repository) : base(context)
        {
            _context = context;
            _repository = repository;
        }
    }
}
