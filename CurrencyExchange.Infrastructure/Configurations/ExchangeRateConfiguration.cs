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
    public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder.ToTable("ExchangeRates");
            builder.HasKey(x => x.Id);
            builder.Property(er => er.RateDate).HasDefaultValueSql("GETDATE()");
            builder.HasOne(er => er.Currency)
                .WithMany(c => c.Rates);
        }
    }
}
