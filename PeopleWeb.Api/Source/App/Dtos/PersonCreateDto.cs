using System.ComponentModel.DataAnnotations;

namespace PeopleWeb.Api.Source.Dtos;

public class PersonCreateDto
{
    [Required(ErrorMessage = "{0} - Is required")]
    [MaxLength(150, ErrorMessage = "{0} - Is too long")]
    public string Name { get; } = string.Empty;

    [Required(ErrorMessage = "{0} - Is required")]
    [MaxLength(11)]
    public string Cpf { get; } = string.Empty;

    [Required(ErrorMessage = "{0} - Is required")]
    public DateTime BirthDate { get; } = new();

    [MaxLength(10, ErrorMessage = "{0}, - Is too long")]
    public string? Gender { get; } = null;
    
    [MaxLength(100, ErrorMessage = "{0} - Is too long")]
    public string? BirthPlace { get; } = null;
    
    [MaxLength(100, ErrorMessage = "{0} - Is too long")]
    public string? Nationality { get; } = null;

    [EmailAddress(ErrorMessage = "{0} - Is not a valid email address. Try put '@'.")]
    [MaxLength(50, ErrorMessage = "{0} - Is too long")]
    public string? Email { get; } = null;
}