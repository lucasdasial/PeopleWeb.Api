using System.ComponentModel.DataAnnotations;

namespace PeopleWeb.Api.Source.Domain.Entities;

public class Address
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(8)]
    public string Cep { get; set; } = string.Empty;

    [Required]
    [MaxLength(2)]
    public string Uf { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string District { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Street { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    public string Number { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}