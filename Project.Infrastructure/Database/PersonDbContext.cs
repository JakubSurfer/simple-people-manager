using System.Data.Entity;
using Project.Domain;
using Project.Domain.Entities;

namespace Project.Infrastructure.Database
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext() : base("ProjectDb") { }
        public DbSet<Person> Persons { get; set; }
    }
}
