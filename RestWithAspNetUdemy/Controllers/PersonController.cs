using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Services.Implementations;

namespace RestWithAspNetUdemy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private IPersonServices _personService;

    public PersonController(ILogger<PersonController> logger, IPersonServices personServices)
    {
        _logger = logger;
        _personService = personServices;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {
        var person = _personService.FindByID(id);
        if(person == null) return NotFound();
        return Ok(person);
    }

    [HttpPost]
    public IActionResult PostCreate([FromBody] Person person)
    {
        if (person == null) return BadRequest();
        return Ok(_personService.Create(person));
    }

    [HttpPut]
    public IActionResult PutUpadate([FromBody] Person person)
    {
        if (person == null) return BadRequest();
        return Ok(_personService.Update(person));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(long id)
    {
         _personService.Delete(id);
        return NoContent();
    }
}
