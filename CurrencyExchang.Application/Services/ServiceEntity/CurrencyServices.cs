using CurrencyExchange.Application.Services.Interfaces;
using CurrencyExchange.Core.Entities;
using CurrencyExchange.Core.Interfaces;
using Market.api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Services.ServiceEntity
{
    public class CurrencyServices : Services<Currency>, ICurrencyServices
    {
        public CurrencyServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
