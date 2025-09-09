using PeopleWeb.Api.Source.Dtos;

namespace PeopleWeb.Api.Source.Domain.Entities;

public class Person
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Cpf { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Gender { get; set; } = null;
    public string? BirthPlace { get; set; }
    public string? Nationality { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Address? Address { get; set; }
    public Guid? AddressId { get; set; }

    public PersonReadDto ToReadDto()
    {
        return new PersonReadDto
        {
            Id = Id,
            Name = Name,
            Cpf = Cpf,
            BirthDate = BirthDate,
            BirthPlace = BirthPlace,
            Nationality = Nationality,
            Gender = Gender,
            Email = Email,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt

        };
    }
    
    public PersonReadWithAddressDto ToReadWithAddressDto()
    {
        return new PersonReadWithAddressDto
        {
            Id = Id,
            Name = Name,
            Cpf = Cpf,
            BirthDate = BirthDate,
            BirthPlace = BirthPlace,
            Nationality = Nationality,
            Gender = Gender,
            Email = Email,
            Address = Address,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt
        };
    }
    
}