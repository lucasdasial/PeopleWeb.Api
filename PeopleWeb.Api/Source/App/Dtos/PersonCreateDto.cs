using System.ComponentModel.DataAnnotations;

namespace PeopleWeb.Api.Source.Dtos;

public class PersonCreateDto
{
    [Required(ErrorMessage = "{0} - é obrigatório")]
    [MaxLength(150, ErrorMessage = "{0} - muito extenso")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} - é obrigatório")]
    [MaxLength(11)]
    public string Cpf { get; set;} = string.Empty;

    [Required(ErrorMessage = "{0} - é obrigatório")]
    public DateTime BirthDate { get;set; } = new();

    [MaxLength(10, ErrorMessage = "{0}, - muito extenso")]
    public string? Gender { get; set;} = null;
    
    [MaxLength(100, ErrorMessage = "{0} - muito extenso")]
    public string? BirthPlace { get; set;} = null;
    
    [MaxLength(100, ErrorMessage = "{0} - muito extenso")]
    public string? Nationality { get; set;} = null;

    [EmailAddress(ErrorMessage = "{0} - Formato de e-mail inválido")]
    [MaxLength(50, ErrorMessage = "{0} - muito extenso")]
    public string? Email { get; set; } = null;
}