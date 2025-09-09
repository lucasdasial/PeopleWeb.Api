using System.ComponentModel.DataAnnotations;
using PeopleWeb.Api.Source.Domain.Entities;

namespace PeopleWeb.Api.Source.Dtos;

public class PersonUpdateWithAddressDto: PersonUpdateDto
{
    [Required] public Address Address { get; set; } = new();
}