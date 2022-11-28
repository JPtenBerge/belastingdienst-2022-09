using Demo.Shared.Entities;
using DemoProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DemoProject.Controllers;

[Route("api/person")]
[ApiController] // ModelState.IsValid [FromBody]
public class PersonController : ControllerBase
{
    private IPersonRepository _personRepository;

    public PersonController(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<PersonEntity>> Get()
    {
        return await _personRepository.GetAllAsync();
    }

    [HttpPost]
    public async Task<PersonEntity> Post(PersonEntity newPerson) // model binding
    {
        await _personRepository.AddAsync(newPerson);
        return newPerson; // return updated entity
    }
}