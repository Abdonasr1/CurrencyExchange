using CurrencyExchange.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CurrencyExchange.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            #region
            //var countries = new List<Core.Entities.Country>();
            //var currencies = new List<Core.Entities.Currency>();
            //var exchangeRates = new List<ExchangeRate>();



            //var helper = new CountryHelper();
            //foreach (var country in helper.GetCountryData())
            //{
            //    var curre = country.Currency;
            //    if (curre != null)
            //    {
            //        foreach (var currency in country.Currency)
            //        {
            //            currencies.Add(new Core.Entities.Currency
            //            {
            //                Id = currencies.Count + 1,
            //                CurrencyName = currency.Name,
            //                CurrencyCode = currency.Code
            //            });
            //            countries.Add(new Core.Entities.Country
            //            {
            //                Id = countries.Count + 1,
            //                CountryName = country.CountryName,
            //                CountryCode = country.CountryShortCode,
            //                CurrencyId = currencies.First(c => c.CurrencyCode == currency.Code).Id
            //            });

            //        }
            //    }
            //}

            //var random = new Random();
            //foreach (var currency in currencies)
            //{
            //    exchangeRates.Add(new ExchangeRate
            //    {
            //        Id = exchangeRates.Count + 1,
            //        CurrencyId = currency.Id,
            //        Rate = (decimal)(random.NextDouble() * (10 - 0.5) + 0.5),
            //        RateDate = DateOnly.FromDateTime(DateTime.UtcNow)
            //    });
            //}

            //modelBuilder.Entity<Core.Entities.Currency>().HasData(currencies);
            //modelBuilder.Entity<Core.Entities.Country>().HasData(countries);
            //modelBuilder.Entity<ExchangeRate>().HasData(exchangeRates);
            #endregion

        }
    }
}
