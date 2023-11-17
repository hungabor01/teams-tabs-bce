using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeamsTabsBCE.Database.Core;
using TeamsTabsBCE.Database.Core.Entities;

namespace TeamsTabsBCE.Database.Repositories.Repository
{
    internal abstract class Repository<TEntity> where TEntity : class, IEntity
    {
        protected BceDbContext Context { get; set; }

        public Repository(BceDbContext context)
        {
            Context = context;
        }

        protected TEntity? Get(int id) =>
            Context.Set<TEntity>().Find(id);

        protected async Task<TEntity?> GetAsync(int id) =>
            await Context.Set<TEntity>().FindAsync(id);

        protected IList<TEntity> GetAll() =>
            Context.Set<TEntity>().ToList();

        protected async Task<IList<TEntity>> GetAllAsync() =>
            await Context.Set<TEntity>().ToListAsync();

        protected IList<TEntity> Find(Expression<Func<TEntity, bool>> predicate) =>
            Context.Set<TEntity>().Where(predicate).ToList();

        protected async Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) =>
            await Context.Set<TEntity>().Where(predicate).ToListAsync();

        protected async Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include) =>
            await Context.Set<TEntity>().Where(predicate).Include(include).ToListAsync();

        protected TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate) =>
            Context.Set<TEntity>().SingleOrDefault(predicate);

        protected async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) =>
            await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);

        protected async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include) =>
            await Context.Set<TEntity>().Include(include).SingleOrDefaultAsync(predicate);

        protected TEntity Add(TEntity entity) =>
            Context.Set<TEntity>().Add(entity).Entity;

        protected async Task<TEntity> AddAsync(TEntity entity) =>
            (await Context.Set<TEntity>().AddAsync(entity)).Entity;

        protected void AddRange(IEnumerable<TEntity> entities) =>
            Context.Set<TEntity>().AddRange(entities);

        protected async Task AddRangeAsync(IEnumerable<TEntity> entities) =>
            await Context.Set<TEntity>().AddRangeAsync(entities);

        protected void Remove(TEntity entity) =>
            Context.Set<TEntity>().Remove(entity);

        protected void RemoveRange(IEnumerable<TEntity> entities) =>
            Context.Set<TEntity>().RemoveRange(entities);
    }
}
