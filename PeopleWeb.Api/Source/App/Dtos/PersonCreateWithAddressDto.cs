using PeopleWeb.Api.Source.Domain.Entities;

namespace PeopleWeb.Api.Source.Dtos;

public class PersonCreateWithAddressDto : PersonCreateDto
{
    public Address Address { get; set; } = new();
}