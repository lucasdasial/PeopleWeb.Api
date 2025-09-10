using System.ComponentModel.DataAnnotations;

namespace PeopleWeb.Api.Source.Dtos;

public class PersonUpdateDto
{
    
    [MaxLength(150, ErrorMessage = "{0} -muito extenso")]
    public string? Name { get; set; } = string.Empty;
    
    [MaxLength(11)]
    public string? Cpf { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    
    [MaxLength(10, ErrorMessage = "{0} -muito extenso")]
    public string? Gender { get; set; }
    
    [MaxLength(100, ErrorMessage = "{0} -muito extenso")]
    public string? BirthPlace { get; set; }
    
    [MaxLength(100, ErrorMessage = "{0} -muito extenso")]
    public string? Nationality { get; set; }

    [EmailAddress(ErrorMessage = "{0} - Formato de e-mail inválido")]
    [MaxLength(50, ErrorMessage = "{0} - muito extenso")]
    public string? Email { get; set; }
    
}