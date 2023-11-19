using TeamsTabsBCE.BusinessLogic.Interfaces.DatabaseAccess;
using TeamsTabsBCE.DatabaseAccess.Mappers.TaskIdentifierMapper;
using TeamsTabsBCE.DatabaseAccess.Mappers.TaskResultMapper;
using TeamsTabsBCE.DatabaseAccess.Mappers.TeamsConversationMapper;
using TeamsTabsBCE.DatabaseAccess.RepositoryHandlers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DatabaseAccessStartupExtensions
    {
        public static void AddDatabaseAccess(this IServiceCollection services)
        {
            services.AddScoped<ITaskResultRepositoryHandler, TaskResultRepositoryHandler>();
            services.AddScoped<ITeamsConversationRepositoryHandler, TeamsConversationRepositoryHandler>();

            services.AddScoped<ITaskIdentifierMapper, TaskIdentifierMapper>();
            services.AddScoped<ITaskResultMapper, TaskResultMapper>();
            services.AddScoped<ITeamsConversationMapper, TeamsConversationMapper>();
        }
    }
}