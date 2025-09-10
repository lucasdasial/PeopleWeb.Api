using PeopleWeb.Api.Source.Domain.Entities;
using PeopleWeb.Api.Source.Domain.Interfaces;
using PeopleWeb.Api.Source.Dtos;
using ValidationException = PeopleWeb.Api.Source.Domain.Execptions.ValidationException;

namespace PeopleWeb.Api.Source.Services;

public class PersonService(IPersonRepository repository, IDocumentService documentService): IPersonService
{
    public async Task<List<PersonReadDto>> GetAllAsync()
    {
        var people = await repository.GetAllAsync();
        return people.Select(p => p.ToReadDto()).ToList();
    }
    
    public async Task<List<PersonReadWithAddressDto>> GetAllWithAddressAsync()
    {
        var people = await repository.GetAllAsync();
        return people.Select(p => p.ToReadWithAddressDto()).ToList();
    }

    public async Task<PersonReadDto?> GetByIdAsync(Guid id)
    {
        var person =  await repository.GetByIdAsync(id);
        return person?.ToReadDto();
    }
    
    public async Task<PersonReadWithAddressDto?> GetByIdWithAddressAsync(Guid id)
    {
        var person =  await repository.GetByIdAsync(id);
        return person?.ToReadWithAddressDto();
    }

    public async Task<Person> CreateAsync(PersonCreateDto dto)
    {
        if (!documentService.ValidateCpf(dto.Cpf))
            throw new  ValidationException("CPF formato inválido");
        
        if (await repository.ExistsByCpf(dto.Cpf))
            throw new  ValidationException("CPF já utilizado");
        
        
        var person = new Person
        {
            Name = dto.Name,
            Cpf = dto.Cpf,
            BirthDate = dto.BirthDate,
            Gender = dto.Gender,
            BirthPlace = dto.BirthPlace,
            Nationality = dto.Nationality,
            Email = dto.Email
        };

        await repository.AddAsync(person);
        return person;
    }

    public async Task<Person> CreateWithAddressAsync(PersonCreateWithAddressDto dto)
    {
        if (!documentService.ValidateCpf(dto.Cpf))
            throw new  ValidationException("CPF formato inválido");
        
        if (await repository.ExistsByCpf(dto.Cpf))
            throw new  ValidationException("CPF já utilizado");
        
        var address = new Address
        {
            Cep = dto.Address.Cep,
            Uf = dto.Address.Uf,
            City = dto.Address.City,
            District = dto.Address.District,
            Street = dto.Address.Street,
            Number = dto.Address.Number
        };

        var person = new Person
        {
            Name = dto.Name,
            Cpf = dto.Cpf,
            BirthDate = dto.BirthDate,
            Gender = dto.Gender,
            BirthPlace = dto.BirthPlace,
            Nationality = dto.Nationality,
            Email = dto.Email,
            Address = address
        };

        await repository.AddAsync(person);
        return person;
    }
    
    public async Task<PersonReadDto?> UpdateAsync(Guid id, PersonUpdateDto dto)
    {
        var person = await repository.GetByIdAsync(id);
        if (person == null) return null;

        person.Name = dto.Name?? person.Name;
        person.Cpf = dto.Cpf ?? person.Cpf;
        person.BirthDate = dto.BirthDate ?? person.BirthDate;
        person.Gender = dto.Gender ?? person.Gender;
        person.BirthPlace = dto.BirthPlace ?? person.BirthPlace;
        person.Nationality = dto.Nationality ?? person.Nationality;
        person.Email = dto.Email ?? person.Email;
        person.UpdatedAt = DateTime.UtcNow;

        await repository.UpdateAsync(person);
        return person.ToReadDto();
    }
    
    public async Task<PersonReadWithAddressDto?> UpdateWithAddressAsync(Guid id, PersonUpdateWithAddressDto dto)
    {
        var person = await repository.GetByIdAsync(id);;

        if (person == null) return null;

        person.Name = dto.Name ?? person.Name;
        person.Cpf = dto.Cpf ?? person.Cpf;
        person.BirthDate = dto.BirthDate?? person.BirthDate;
        person.Gender = dto.Gender  ?? person.Gender;
        person.BirthPlace = dto.BirthPlace ?? person.BirthPlace;
        person.Nationality = dto.Nationality?? person.Nationality;
        person.Email = dto.Email?? person.Email;
        person.UpdatedAt = DateTime.UtcNow;

        person.Address.Cep = dto.Address.Cep;
        person.Address.Uf = dto.Address.Uf;
        person.Address.City = dto.Address.City;
        person.Address.District = dto.Address.District;
        person.Address.Street = dto.Address.Street;
        person.Address.Number = dto.Address.Number;

        await  repository.UpdateAsync(person);
        return person.ToReadWithAddressDto();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var person = await repository.GetByIdAsync(id);
        if (person == null) return false;

        await repository.DeleteAsync(person);
        return true;
    }
    
}