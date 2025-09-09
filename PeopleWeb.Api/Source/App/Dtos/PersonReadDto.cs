namespace PeopleWeb.Api.Source.Dtos;

public class PersonReadDto
{
    public required Guid Id  { get; set; }
    public required string Name { get; set; } = string.Empty;
    public string? Cpf { get; set; }
    public required DateTime BirthDate { get; set; }
    public string? Gender { get; set; }
    public string? BirthPlace { get; set; }
    public string? Nationality { get; set; }
    public string? Email { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}