using Microsoft.EntityFrameworkCore;
using PeopleWeb.Api.Source.Domain.Entities;

namespace PeopleWeb.Api.Source.Infra.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Person>()
                        .HasIndex(p => p.Cpf)
                        .IsUnique();
                
                modelBuilder.Entity<Person>()
                        .HasOne(p => p.Address)
                        .WithOne()
                        .HasForeignKey<Person>(p => p.AddressId)
                        .OnDelete(DeleteBehavior.Cascade);


        }
}