using System.Linq.Expressions;

namespace TeamsTabsBCE.Database.Repositories.Repository
{
    public interface IRepository<TEntity>
    {
        public TEntity? Get(int id);

        public Task<TEntity?> GetAsync(int id);

        public IList<TEntity> GetAll();

        public Task<IList<TEntity>> GetAllAsync();

        public IList<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        public Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        public Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include);

        public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        public Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        public Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include);

        public TEntity Add(TEntity entity);

        public Task<TEntity> AddAsync(TEntity entity);

        public void AddRange(IEnumerable<TEntity> Entities);

        public Task AddRangeAsync(IEnumerable<TEntity> Entities);

        public void Remove(TEntity entity);

        public void RemoveRange(IEnumerable<TEntity> Entities);
    }
}
