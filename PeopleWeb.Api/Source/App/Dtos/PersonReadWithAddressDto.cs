using PeopleWeb.Api.Source.Domain.Entities;

namespace PeopleWeb.Api.Source.Dtos;

public class PersonReadWithAddressDto : PersonReadDto
{
    public Address? Address { get; set; }
}