using Project.Domain.Entities;
using Project.Infrastructure.Database;

namespace Project.Infrastructure.Store
{
    public class DbDataStore : DataStore<Person>
    {
        private readonly IDbRepository<Person> _repository;

        public DbDataStore(IDbRepository<Person> repository)
        {
            _repository = repository;
        }

        protected override bool CheckIfExist(Person entity)
        {
            return _repository.Exist(x => x.Name == entity.Name && x.Secondname == entity.Secondname);
        }

        protected override void Save(Person entity)
        {
            _repository.Add(entity);
        }
    }
}
