using Microsoft.AspNetCore.Mvc;
using PersonREST.Model;
using PersonREST.Services.Implementations;

namespace PersonREST.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("v1/api/")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet, Route("ListPerson")]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet, Route("SearchPerson/{id}")]
        public IActionResult Get(long id)
        {
            OkObjectResult person = Ok(_personService.FindByID(id));
            if(person == null) 
                return NotFound();
            return Ok(person);
        }

        [HttpPost, Route("AddPerson")]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null)
                return BadRequest();
            return Ok(_personService.Create(person));
        } 
        
        [HttpPut, Route("UpdatePerson")]
        public IActionResult Put([FromBody]Person person)
        {
            if (person == null)
                return BadRequest();
            return Ok(_personService.Update(person));
        }

        [HttpDelete, Route("RemovePerson/{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}