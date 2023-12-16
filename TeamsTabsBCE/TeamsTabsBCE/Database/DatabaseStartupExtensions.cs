using TeamsTabsBCE.Database.UnitOfWork;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DatabaseStartupExtensions
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}