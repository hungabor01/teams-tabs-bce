using TeamsTabsBCE.BusinessLogic.Interfaces.DatabaseAccess;
using TeamsTabsBCE.DatabaseAccess.Mappers.TaskIdentifierMapper;
using TeamsTabsBCE.DatabaseAccess.Mappers.TaskResultMapper;
using TeamsTabsBCE.DatabaseAccess.RepositoryHandlers.TaskResultRepositoryHandler;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DatabaseAccessStartupExtensions
    {
        public static void AddDatabaseAccess(this IServiceCollection services)
        {
            services.AddScoped<ITaskResultRepositoryHandler, TaskResultRepositoryHandler>();

            services.AddScoped<ITaskIdentifierMapper, TaskIdentifierMapper>();
            services.AddScoped<ITaskResultMapper, TaskResultMapper>();
        }
    }
}