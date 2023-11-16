﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeamsTabsBCE.Database.Core;

namespace TeamsTabsBCE.Database.Repositories.Repository
{
    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected BceDbContext Context { get; set; }

        public Repository(BceDbContext context)
        {
            Context = context;
        }

        public TEntity? Get(int id) =>
            Context.Set<TEntity>().Find(id);

        public async Task<TEntity?> GetAsync(int id) =>
            await Context.Set<TEntity>().FindAsync(id);

        public IList<TEntity> GetAll() =>
            Context.Set<TEntity>().ToList();

        public async Task<IList<TEntity>> GetAllAsync() =>
            await Context.Set<TEntity>().ToListAsync();

        public IList<TEntity> Find(Expression<Func<TEntity, bool>> predicate) =>
            Context.Set<TEntity>().Where(predicate).ToList();

        public async Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) =>
            await Context.Set<TEntity>().Where(predicate).ToListAsync();

        public async Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include) =>
            await Context.Set<TEntity>().Where(predicate).Include(include).ToListAsync();

        public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate) =>
            Context.Set<TEntity>().SingleOrDefault(predicate);

        public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) =>
            await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);

        public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include) =>
            await Context.Set<TEntity>().Include(include).SingleOrDefaultAsync(predicate);

        public TEntity Add(TEntity entity) =>
            Context.Set<TEntity>().Add(entity).Entity;

        public async Task<TEntity> AddAsync(TEntity entity) =>
            (await Context.Set<TEntity>().AddAsync(entity)).Entity;

        public void AddRange(IEnumerable<TEntity> entities) =>
            Context.Set<TEntity>().AddRange(entities);

        public async Task AddRangeAsync(IEnumerable<TEntity> entities) =>
            await Context.Set<TEntity>().AddRangeAsync(entities);

        public void Remove(TEntity entity) =>
            Context.Set<TEntity>().Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) =>
            Context.Set<TEntity>().RemoveRange(entities);
    }
}
