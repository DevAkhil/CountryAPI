using CountryAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CountryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        List<Country> countries = new List<Country>()
        {
            new Country(){Code = "AUT", Name = "Austria", Region = "Europe",},
            new Country(){Code ="BEL", Name = "Belgium", Region = "Europe"},
            new Country(){Code = "EGY", Name = "Egypt", Region = "Africa"},
            new Country(){Code = "COL", Name = "Colombia", Region = "South America"},
            new Country(){Code = "USA", Name = "United States of America", Region = "North America"},
            new Country(){Code = "QAT", Name = "Qatar", Region = "Asia"},
        };



        /// <summary>
        /// Returns a list of coutries
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get api/Country/GetAll
        ///
        /// </remarks>
        /// <returns>IEnumerable of country</returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            if(countries.Count == 0)
            {
                return Ok("No counties have been captured yet");
            }

            return Ok(countries);
        }



        /// <summary>
        /// Returns a list of coutries matching provided region
        /// </summary>
        ///  <param name="region">Region to search for (Asia, Africa, North America, South America, Antarctica, Europe, Australia)</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get api/Country/GetByRegion/{region}
        ///
        /// </remarks>
        /// <returns>IEnumerable of country</returns>
        [HttpGet("GetByRegion/{region}")]
        public IActionResult GetByRegion(string region)
        {
            List<string> possibleRegions = new List<string>
            {
                "Asia", "Africa", "North America", "South America", "Antarctica", "Europe", "Australia"
            };

            bool matchedRegion = possibleRegions.Contains(region);

            if (!matchedRegion){

                ModelState.AddModelError(region, "Please provide a valid region (Asia, Africa, North America, South America, Antarctica, Europe, Australia)");
                return BadRequest(ModelState);
            }

            List<Country> byRegion = countries.FindAll(x => x.Region == region);

            if (byRegion.Count == 0)
            {
                return Ok("No countries found in " + region);

            }

            return Ok(byRegion);


        }
        /// <summary>
        /// Returns the country that matches the code provided 
        /// </summary>
        ///  <param name="code">ISO 3166-1 alpha-3 Country code to search for (AUT, USA, QAT)</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get api/Country/GetByCountryCode/{code}
        ///
        /// </remarks>
        /// <returns>A country</returns>
        [HttpGet("GetByCountryCode/{code}")]
        public IActionResult GetByCountryCode(string code)
        {
            if(code.Length != 3)
            {

                ModelState.AddModelError(code, "Invalid country code provided (ISO 3166-1 alpha-3 code required)");
                return BadRequest(ModelState);

            }
            var byCode = countries.Find(x => x.Code == code);

            if(byCode == null)
            {

                return Ok("No country found with code: " + code);
            }


            return Ok(byCode);
        }
      
    }
}
