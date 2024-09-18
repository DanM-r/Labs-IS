using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend_lab.Models;

using backend_lab.Handlers;

namespace backend_lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly CountryHandler _countriesHandler;

        public CountriesController()
        {
            _countriesHandler = new CountryHandler();
        }

        [HttpGet]
        public List<CountryModel> Get()
        {
            var countries = _countriesHandler.ObtenerPaises();
            return countries;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateCountry(CountryModel country)
        {
            try
            {
                if (country == null)
                {
                    return BadRequest();
                }

                CountryHandler countryHandler = new CountryHandler();
                var response = countryHandler.CrearPais(country);
                return new JsonResult(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating a country");
            }
        }
    }
}
