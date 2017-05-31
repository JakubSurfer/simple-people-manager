using Project.Domain.Entities;

namespace Project.Infrastructure.Database
{
    public class PersonRepository : DbRepository<PersonDbContext, Person>
    {
        public PersonRepository(PersonDbContext dbContext) : base(dbContext)
        {
        }
    }
}
