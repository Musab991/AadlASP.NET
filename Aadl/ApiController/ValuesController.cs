using Aadl.Models.api;
using BusinessLib.Bl.Contract;
using Domains.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aadl.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICRUD<TbCountry> _clsCountry;
        private readonly ICRUD<TbPerson> _clsPerson;

        public ValuesController(ICRUD <TbCountry>countryService,ICRUD<TbPerson>personService)
        {
            
            _clsCountry = countryService;
            _clsPerson = personService;
        }
        // GET: api/<ValuesController>/Countries
        [HttpGet("Countries")]
        public IActionResult GetCountries()
        {
            try
            {
                var result = _clsCountry.GetAll();

                var apiResponse = new ApiResponse
                {
                    Data = result,
                    Errors = null,
                    StatusCode = "200"
                };

                return Ok(apiResponse); // Automatically sets status code to 200
            }
            catch (Exception ex)
            {
                var apiResponse = new ApiResponse
                {
                    Data = null,
                    Errors = new List<string> {"Failed to retrieve countries from the database.",
                                               ex.Message, // Detailed exception message
                                               "Please check the database connection."}, // Return errors as a list for better structure
                    StatusCode = "500" // More appropriate for server errors
                };

                return StatusCode(500, apiResponse); // Use StatusCode to specify a custom status code
            }
        }

        // GET: api/<ValuesController>/People
        [HttpGet("People")]
        public IActionResult GetPeople()
        {
            try
            {
                var result = _clsPerson.GetAll();

                var apiResponse = new ApiResponse
                {
                    Data = result,
                    Errors = null,
                    StatusCode = "200"
                };

                return Ok(apiResponse); // Automatically sets status code to 200
            }
            catch (Exception ex)
            {
                var apiResponse = new ApiResponse
                {
                    Data = null,
                    Errors = new List<string> { ex.Message }, // Return errors as a list for better structure
                    StatusCode = "500" // More appropriate for server errors
                };

                return StatusCode(500, apiResponse); // Use StatusCode to specify a custom status code
            }

        }

        // GET api/<ValuesController>/5
        [HttpGet("GetCountry/{id}")]
        public IActionResult GetCountryById(int id)

        {
            try
            {
                var result = _clsCountry.GetById(id);

                var apiResponse = new ApiResponse
                {
                    Data = result,
                    Errors = null,
                    StatusCode = "200"
                };

                return Ok(apiResponse); // Automatically sets status code to 200
            }
            catch (Exception ex)
            {
                var apiResponse = new ApiResponse
                {
                    Data = null,
                    Errors = new List<string> { ex.Message }, // Return errors as a list for better structure
                    StatusCode = "500" // More appropriate for server errors
                };

                return StatusCode(500, apiResponse); // Use StatusCode to specify a custom status code
            }

        }


        [HttpPost("CreateCountry")]
        public IActionResult CreateCountry([FromBody] TbCountry country)
        {
            if (country == null)
            {
                var errors = new List<string>
            {
            "The request body is null.",
            "Please provide valid country details."
            };

                var apiResponse = new ApiResponse
                {
                    Data = null,
                    Errors = errors,
                    StatusCode = "400"
                };

                return BadRequest(apiResponse);
            }

            try
            {
                _clsCountry.Save(country);

                var apiResponse = new ApiResponse
                {
                    Data = "Country created successfully.",
                    Errors = null,
                    StatusCode = "201"
                };

                return StatusCode(201, apiResponse); // 201 Created
            }
            catch (Exception ex)
            {
                var errors = new List<string>
            {
            "Failed to create the country.",
            ex.Message, // Detailed exception message
            "Please try again or contact support."
            };

                var apiResponse = new ApiResponse
                {
                    Data = null,
                    Errors = errors,
                    StatusCode = "500"
                };

                return StatusCode(500, apiResponse);
            }
        }


    }
}
