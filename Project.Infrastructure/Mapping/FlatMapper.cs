using AutoMapper;

namespace Project.Infrastructure.Mapping
{
    public interface IFlatMapper
    {
        TResult Map<TEntity, TResult>(TEntity entity);
    }

    public class FlatMapper : IFlatMapper
    {
        public TResult Map<TEntity, TResult>(TEntity entity)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TEntity, TResult>());
            var mapped = Mapper.Map<TEntity, TResult>(entity);
            return mapped;
        }
    }
}
