using TeamsTabsBCE.BusinessLogic.Interfaces.Services;
using TeamsTabsBCE.Services.ContentCreator;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesStartupExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IContentCreator, ContentCreator>();
        }
    }
}