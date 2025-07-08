using CurrencyExchange.Core.Entities;
using CurrencyExchange.Core.Interfaces;
using CurrencyExchange.Infrastructure.Persistence;
using CurrencyExchange.Infrastructure.Persistence.Repositories;
using System;

public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
{
    private readonly AppDbContext _context;
    private readonly IRepository<Currency> _repository;

    public CurrencyRepository(AppDbContext context, IRepository<Currency> repository) : base(context)
    {
        _context = context;
        _repository = repository;
    }
}
