
using CurrencyExchange.Application.Services.Interfaces;
using CurrencyExchange.Core.Entities;
using CurrencyExchange.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryservices _countryServices;
        public CountryController( ICountryservices countryservices )
        {
            _countryServices = countryservices;
        }

        [HttpGet]
        public async Task<IEnumerable<Country>> GetAllCountry()
        {
            var countries = await _countryServices.GetAllAsync();
            return countries;
        }

        [HttpGet("id")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid product ID.");
            }
            var country = await _countryServices.GetByIdAsync(id);
            

            if (country == null)
            {
                return NotFound("This is id not available.");
            }
            return Ok(new
            {
                CountryId = country.Id,
                CountryName = country.CountryName,
                CountryCode = country.CountryCode,
                
            });
        }

        [HttpPost("add")]
        public async Task<ActionResult<Country>> AddCountry([FromBody] Country country)
        {
            await _countryServices.AddAsync(country);
            return Ok(country);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCountry(int id, [FromBody] Country country)
        {
            if (country == null || id != country.Id)
            {
                return BadRequest("Country ID mismatch.");
            }

            await _countryServices.UpdateAsync(country);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            var isDeleted = await _countryServices.RemoveAsync(id);

            if (!isDeleted)
                return NotFound($"Country with ID {id} not found.");

            return Ok($"Country with ID {id} has been successfully removed.");
        }
    }
}
