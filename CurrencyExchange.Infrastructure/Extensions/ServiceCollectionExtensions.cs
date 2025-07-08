using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CurrencyExchange.Infrastructure.Persistence;
using CurrencyExchange.Core.Interfaces;
using CurrencyExchange.Infrastructure.Persistence.Repositories;
using CountryData.Standard;
using CurrencyExchange.Application.Services.Interfaces;
using Market.api.Services;
using CurrencyExchang.Application.Services.ServiceEntity;
using CurrencyExchange.Application.Services.ServiceEntity;


namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            // Register DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IServices<>), typeof(Services<>));
            services.AddScoped(typeof(ICountryRepository), typeof(CountryRepository));
            services.AddScoped(typeof(ICurrencyRepository), typeof(CurrencyRepository));
            services.AddScoped(typeof(ICountryservices), typeof(CountryService));
            services.AddScoped(typeof(ICurrencyServices), typeof(CurrencyServices));
            services.AddScoped(typeof(IRateRepository), typeof(ExchangeRateRepository));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }

        public static void SeedData(this IServiceProvider services)
        {
            // Seed data
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Apply migrations
                context.Database.Migrate();

                // Seed data
                if (!context.Countries.Any())
                {
                    var countriesList = new List<CurrencyExchange.Core.Entities.Country>();
                    var currenciesList = new List<CurrencyExchange.Core.Entities.Currency>();
                    var helper = new CountryHelper();
                    
                    var countriesData = helper.GetCountryData().ToList();                    

                    foreach(var countryData in countriesData)
                    {
                        var countryCurrency = countryData.Currency?.FirstOrDefault();
                        if (countryCurrency != null && !string.IsNullOrEmpty(countryCurrency.Name))
                        {
                            var currency = new CurrencyExchange.Core.Entities.Currency
                            {
                                CurrencyCode = countryCurrency.Code,
                                //CountryId = context.Countries.FirstOrDefault(c => c.CountryName == countryData.CountryName)?.Id
                            };
                            currenciesList.Add(currency);
                        }
                    }
                    context.Currencies.AddRangeAsync(currenciesList.Distinct());
                    context.SaveChanges();

                    foreach (var countryData in countriesData)
                    {
                        if(countryData.Currency != null)
                        {
                            var curencyCode = helper.GetCurrencyCodesByCountryCode(countryData.CountryShortCode).FirstOrDefault()?.Code;

                            var country = new CurrencyExchange.Core.Entities.Country
                            {
                                CountryName = countryData.CountryName,
                                CountryCode = countryData.CountryShortCode,
                                CurrencyId = context.Currencies.Where(c => c.CurrencyCode == curencyCode).FirstOrDefault()?.Id
                            };
                            countriesList.Add(country);
                        }
                    }
                    context.Countries.AddRangeAsync(countriesList);
                    context.SaveChanges();
                }
            }
        }
    }
}
