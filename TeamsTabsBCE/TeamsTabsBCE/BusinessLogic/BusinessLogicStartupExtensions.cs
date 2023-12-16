using TeamsTabsBCE.BusinessLogic.ControllerHandlers;
using TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BusinessLogicStartupExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IConfigureControllerHandler, ConfigureControllerHandler>();
            services.AddScoped<ISoftengControllerHandler, SoftengControllerHandler>();
            services.AddScoped<ISoftengDashboardControllerHandler, SoftengDashboardControllerHandler>();
        }
    }
}