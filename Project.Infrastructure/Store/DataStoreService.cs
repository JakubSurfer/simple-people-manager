using System.Collections.Generic;
using System.Linq;

namespace Project.Infrastructure.Store
{
    public interface IDataStoreService<in TEntity>
        where TEntity : class
    {
        void SaveAll(TEntity entity);
    }

    public class DataStoreService<TEntity> : IDataStoreService<TEntity>
        where TEntity : class
    {
        private readonly IEnumerable<IDataStore<TEntity>> _dataStores;

        public DataStoreService(IEnumerable<IDataStore<TEntity>> dataStores)
        {
            _dataStores = dataStores;
        }

        public void SaveAll(TEntity entity)
        {
            _dataStores.AsParallel().ForAll(x => x.Store(entity));
        }

    }
}