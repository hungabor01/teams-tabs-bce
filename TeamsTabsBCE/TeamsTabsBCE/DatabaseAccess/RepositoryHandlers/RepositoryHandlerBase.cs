using TeamsTabsBCE.Database.UnitOfWork;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.DatabaseAccess.RepositoryHandlers
{
    internal abstract class RepositoryHandlerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public RepositoryHandlerBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected IUnitOfWork GetUnitOfWork()
        {
            var unitOfWork = _serviceProvider.GetService<IUnitOfWork>();
            unitOfWork.ThrowExceptionIfNull(nameof(unitOfWork));

            return unitOfWork;
        }
    }
}
