using NLog;
using Project.Domain.Entities;

namespace Project.Infrastructure.Store
{
    public class FileDataStore : DataStore<Person>
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected override bool CheckIfExist(Person entity)
        {
            return false;
        }

        protected override void Save(Person entity)
        {
            Logger.Info($"{entity.Name},{entity.Secondname}");
        }
    }
}
