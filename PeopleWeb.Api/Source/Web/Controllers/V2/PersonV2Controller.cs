using Microsoft.AspNetCore.Mvc;
using PeopleWeb.Api.Source.Domain.Interfaces;
using PeopleWeb.Api.Source.Dtos;

namespace PeopleWeb.Api.Source.Web.Controllers.V2;

[ApiController]
[Route("/api/v2/person")]
public class PersonV2Controller(IPersonService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<PersonReadWithAddressDto>>> GetAll()
    {
        var people = await service.GetAllWithAddressAsync();
        return Ok(people);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonReadWithAddressDto>> GetById(Guid id)
    {
        var person = await service.GetByIdWithAddressAsync(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpPost]
    public async Task<ActionResult<PersonReadWithAddressDto>> Create([FromBody] PersonCreateWithAddressDto dto)
    {
        var person = await service.CreateWithAddressAsync(dto);
        return  Ok(person.ToReadWithAddressDto());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PersonReadWithAddressDto>> Update(Guid id, [FromBody]  PersonUpdateWithAddressDto dto)
    {
        var updated = await service.UpdateWithAddressAsync(id, dto);
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