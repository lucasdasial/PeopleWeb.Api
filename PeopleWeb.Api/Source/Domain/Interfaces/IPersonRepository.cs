using PeopleWeb.Api.Source.Domain.Entities;

namespace PeopleWeb.Api.Source.Domain.Interfaces;

public interface IPersonRepository
{
    public  Task<List<Person>> GetAllAsync();
    
    public  Task<Person?> GetByIdAsync(Guid id);
    
    public  Task AddAsync(Person person);
    
    public  Task UpdateAsync(Person person);
    
    public  Task DeleteAsync(Person person);
    
    public  Task<bool> ExistsByCpf(string cpf);
}