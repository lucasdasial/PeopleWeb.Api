using Microsoft.AspNetCore.Mvc;
using PeopleWeb.Api.Source.Domain.Interfaces;
using PeopleWeb.Api.Source.Dtos;

namespace PeopleWeb.Api.Source.Web.Controllers.V1;

[ApiController]
[Route("/api/v1/person")]
public class PersonV1Controller(IPersonService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<PersonReadDto>>> GetAll()
    {
        var people = await service.GetAllAsync();
        return Ok(people);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonReadDto>> GetById(Guid id)
    {
        var person = await service.GetByIdAsync(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpPost]
    public async Task<ActionResult<PersonReadDto>> Create([FromBody] PersonCreateDto dto)
    {
        var person = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PersonReadDto>> Update(Guid id, [FromBody] PersonUpdateDto dto)
    {
        var updated = await service.UpdateAsync(id, dto);
        if (updated == null) return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var deleted = await service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}