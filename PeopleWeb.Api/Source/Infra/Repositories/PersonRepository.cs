using Microsoft.EntityFrameworkCore;
using PeopleWeb.Api.Source.Domain.Entities;
using PeopleWeb.Api.Source.Domain.Interfaces;
using PeopleWeb.Api.Source.Infra.Data;

namespace PeopleWeb.Api.Source.Infra.Repositories;

public class PersonRepository(AppDbContext context): IPersonRepository
{
    public async Task<List<Person>> GetAllAsync()
    {
        return await context.People
            .Include(p => p.Address)
            .ToListAsync();
    }

    public async Task<Person?> GetByIdAsync(Guid id)
    {
        return await context.People
            .Include(p => p.Address)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Person person)
    {
        await context.People.AddAsync(person);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Person person)
    {
        context.People.Update(person);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Person person)
    {
        context.People.Remove(person);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByCpf(string cpf)
    {
        return await context.People.AnyAsync(p => p.Cpf == cpf);
    }
}