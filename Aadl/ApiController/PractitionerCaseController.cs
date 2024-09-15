
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using BusinessLib.Bl.Contract;

namespace Aadl.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractitionerCaseController : ControllerBase
    {

        private readonly ISpecialServices<TbCaseType> _clsPractitionerService;

        public PractitionerCaseController(ISpecialServices<TbCaseType> practitionerService)
        {

            _clsPractitionerService = practitionerService;
        }

        // GET: api/practitioner/all
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            
                try
                {
                    var result = _clsPractitionerService.GetAll(id);

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

        // GET api/<PractitionerController>/5

        // POST api/<PractitionerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PractitionerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PractitionerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
