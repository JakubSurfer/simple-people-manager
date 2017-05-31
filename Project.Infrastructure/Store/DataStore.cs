namespace Project.Infrastructure.Store
{
    public interface IDataStore<in TEntity>
        where TEntity: class
    {
        void Store(TEntity entity);
    }

    public abstract class DataStore<TEntity> : IDataStore<TEntity>
        where TEntity : class
    {
        public void Store(TEntity entity)
        {
            if (!CheckIfExist(entity))
                Save(entity);
        }

        protected abstract bool CheckIfExist(TEntity entity);

        protected abstract void Save(TEntity entity);

    }
}
