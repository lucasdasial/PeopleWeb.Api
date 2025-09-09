using System.ComponentModel.DataAnnotations;

namespace PeopleWeb.Api.Source.Dtos;

public class PersonUpdateDto
{
    
    [MaxLength(150, ErrorMessage = "{0} - Is too long")]
    public string? Name { get; set; } = string.Empty;
    
    [MaxLength(11)]
    public string? Cpf { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    
    [MaxLength(10, ErrorMessage = "{0} - Is too long")]
    public string? Gender { get; set; }
    
    [MaxLength(100, ErrorMessage = "{0} - Is too long")]
    public string? BirthPlace { get; set; }
    
    [MaxLength(100, ErrorMessage = "{0} - Is too long")]
    public string? Nationality { get; set; }

    [EmailAddress(ErrorMessage = "{0} - Is not a valid email address. Try put '@'.\"")]
    [MaxLength(50, ErrorMessage = "{0} - Is too long")]
    public string? Email { get; set; }
    
}