using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Core.Entities
{
    public class ExchangeRate:BaseEntity
    {
        public decimal Rate { get; set; }
        public DateOnly RateDate { get; set; }
        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;
    }
}
