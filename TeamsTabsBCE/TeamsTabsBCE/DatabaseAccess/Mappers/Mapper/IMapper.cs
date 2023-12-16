using TeamsTabsBCE.Database.Core.Entities;
using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.DatabaseAccess.Mappers.Mapper
{
    internal interface IMapper<TEntity, TModel>
        where TEntity : IEntity
        where TModel : IModel
    {
        public TEntity FromModel(TModel model);

        public TModel ToModel(TEntity entity);

        public IList<TEntity> FromModels(IEnumerable<TModel> models);

        public IList<TModel> ToModels(IEnumerable<TEntity> entities);
    }
}