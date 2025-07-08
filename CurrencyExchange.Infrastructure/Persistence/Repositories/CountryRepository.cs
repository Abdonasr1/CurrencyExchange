using CurrencyExchange.Core.Entities;
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
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly AppDbContext _context;
        private readonly IRepository<Country> _repository;

        public CountryRepository(AppDbContext context, IRepository<Country> repository) : base(context)
        {
            _context = context;
            _repository = repository;
        }

       
    }
}
