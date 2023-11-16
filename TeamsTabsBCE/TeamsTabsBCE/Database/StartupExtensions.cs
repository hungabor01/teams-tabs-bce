using TeamsTabsBCE.Database.UnitOfWork;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtensions
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}