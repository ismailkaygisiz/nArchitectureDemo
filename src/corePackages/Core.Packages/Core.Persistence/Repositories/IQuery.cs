namespace Core.Persistence.Repositories
{
    public interface IQuery<TEntity>
    {
        IQueryable<TEntity> Query();
    }
}
