using System;
using System.Data.Entity;
using System.Linq;
using Project.Domain;

namespace Project.Infrastructure.Database
{
    public interface IDbRepository<TEntity> : IDisposable
        where TEntity : class, IHaveId
    {
        IQueryable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        bool Exist(Func<TEntity,bool> predicate);
        TEntity Get(int id);
        void Delete(int id);
    }

    public class DbRepository<TDbContext, TEntity> : IDbRepository<TEntity>
        where TEntity : class, IHaveId
        where TDbContext : DbContext
    {
        protected TDbContext _dbContext;

        public DbRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IQueryable<TEntity> GetAll()
        {
            var entityDbSet = GetDbSet();
            return entityDbSet.AsNoTracking();
        }

        public TEntity Add(TEntity entity)  
        {
            var newEntity = GetDbSet().Add(entity);
            _dbContext.SaveChangesAsync();
            return newEntity;
        }

        public bool Exist(Func<TEntity, bool> predicate)
        {
            return GetDbSet().Any(predicate);
        }

        public TEntity Get(int id)
        {
            return GetDbSet().FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var dbctx = GetDbSet();
            var entity = dbctx.FirstOrDefault(x => x.Id == id);
            if (entity != null)
                dbctx.Remove(entity);
            _dbContext.SaveChanges();
        }

        private DbSet<TEntity> GetDbSet()
        {
            return _dbContext.Set<TEntity>();
        }
    }
}
