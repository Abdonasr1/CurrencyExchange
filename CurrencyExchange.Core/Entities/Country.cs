using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Core.Entities
{
    public class Country : BaseEntity
    {
        public string CountryName { get; set; } = null!;
        public string CountryCode { get; set; } = null!;
        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;
    }
}
