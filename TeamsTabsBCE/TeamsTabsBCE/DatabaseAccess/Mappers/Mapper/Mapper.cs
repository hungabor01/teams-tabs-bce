
using TeamsTabsBCE.Database.Core.Entities;
using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.DatabaseAccess.Mappers.Mapper
{
    internal abstract class Mapper<TEntity, TModel> : IMapper<TEntity, TModel> where TEntity : IEntity
        where TModel : IModel
    {
        public abstract TEntity FromModel(TModel model);

        public abstract TModel ToModel(TEntity entity);

        public IList<TEntity> FromModels(IEnumerable<TModel> models)
        {
            var entities = new List<TEntity>();

            foreach (var model in models ?? Enumerable.Empty<TModel>())
            {
                var entity = FromModel(model);
                entities.Add(entity);
            }

            return entities;
        }

        public IList<TModel> ToModels(IEnumerable<TEntity> entities)
        {
            var models = new List<TModel>();

            foreach (var entity in entities ?? Enumerable.Empty<TEntity>())
            {
                var model = ToModel(entity);
                models.Add(model);
            }

            return models;
        }
    }
}
