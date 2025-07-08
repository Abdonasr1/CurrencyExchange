using CountryData.Standard;
using CurrencyExchang.Application.Services.ServiceEntity;
using CurrencyExchange.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CurrencyExchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        readonly ICurrencyServices _currencyServices;
        public CurrencyController( ICurrencyServices currencyServices )
        {
            _currencyServices = currencyServices;
        }


        [HttpGet]
        public async Task<IEnumerable<Core.Entities.Currency>> GetAllCurrency()
        {
            var currency = await _currencyServices.GetAllAsync();
            return currency;
        }

        [HttpGet("id")]
        public async Task<ActionResult<Core.Entities.Currency>> GetCountry(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid product ID.");
            }
            var currency = await _currencyServices.GetByIdAsync(id);


            if (currency == null)
            {
                return NotFound("This is id not available.");
            }
            
            return Ok(new
            {
                CurrencyId = currency.Id,
                CurrencyName = currency.CurrencyName,
                CurrencyCode = currency.CurrencyCode,
                Countries = currency.Countries?.Select(c => new
                {
                    CountryId = c.Id,
                    CountryName = c.CountryName,
                    CountryCode = c.CountryCode
                }),
                ExchangeRates = currency.Rates?.Select(r => new
                {
                    ExchangeRateId = r.Id,
                    Rate = r.Rate,
                    RateDate = r.RateDate
                })
            });
        }

        [HttpPost("add")]
        public async Task<ActionResult<Core.Entities.Currency>> AddCountry([FromBody] Core.Entities.Currency currency)
        {
            await _currencyServices.AddAsync(currency);
            return Ok(currency);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCountry(int id, [FromBody] Core.Entities.Currency currency)
        {
            if (currency == null || id != currency.Id)
            {
                return BadRequest("Currency ID mismatch.");
            }

            await _currencyServices.UpdateAsync(currency);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            var isDeleted = await _currencyServices.RemoveAsync(id);

            if (!isDeleted)
                return NotFound($"Country with ID {id} not found.");

            return Ok($"Country with ID {id} has been successfully removed.");
        }

    }
}
