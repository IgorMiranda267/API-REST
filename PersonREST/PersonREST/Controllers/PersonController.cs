using Microsoft.AspNetCore.Mvc;
using PersonREST.Model;
using PersonREST.Services.Implementations;

namespace PersonREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            OkObjectResult person = Ok(_personService.FindByID(id));
            if(person == null) 
                return NotFound();
            return Ok(person);
        }

        [HttpPost("/create")]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null)
                return BadRequest();
            return Ok(_personService.Create(person));
        } 
        
        [HttpPut("/update")]
        public IActionResult Put([FromBody]Person person)
        {
            if (person == null)
                return BadRequest();
            return Ok(_personService.Update(person));
        }

        [HttpDelete("/delete/{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}