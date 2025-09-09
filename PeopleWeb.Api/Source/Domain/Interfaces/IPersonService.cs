using PeopleWeb.Api.Source.Domain.Entities;
using PeopleWeb.Api.Source.Dtos;

namespace PeopleWeb.Api.Source.Domain.Interfaces;

public interface IPersonService
{
    public Task<List<PersonReadDto>> GetAllAsync();
    
    public Task<List<PersonReadWithAddressDto>> GetAllWithAddressAsync();
    
    public Task<PersonReadDto?> GetByIdAsync(Guid id);
    
    public Task<PersonReadWithAddressDto?> GetByIdWithAddressAsync(Guid id);
    
    public Task<Person> CreateAsync(PersonCreateDto dto);
    
    public Task<Person> CreateWithAddressAsync(PersonCreateWithAddressDto dto);
    
    public Task<PersonReadDto?> UpdateAsync(Guid id, PersonUpdateDto dto);
    
    public Task<PersonReadWithAddressDto?> UpdateWithAddressAsync(Guid id, PersonUpdateWithAddressDto dto);
    
    public Task<bool> DeleteAsync(Guid id);
   
    
   
}