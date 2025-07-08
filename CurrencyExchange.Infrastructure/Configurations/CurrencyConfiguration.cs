using CurrencyExchange.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currencies");
            builder.HasKey(x => x.Id);
            builder.Property(c => c.CurrencyCode).IsRequired();
            builder.Property(c => c.CurrencyName).IsRequired();
            builder.HasMany(c => c.Countries).WithOne(c => c.Currency);
            builder.HasMany(c => c.Rates).WithOne(c => c.Currency);
        }
    }
}
