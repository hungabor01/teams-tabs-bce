using Microsoft.AspNetCore.SignalR;

namespace TeamsTabsBCE.Hubs
{
    public class SoftengDashboardHub : Hub
    {
        public static string Url => "/softeng-dashboard-hub";
        public static string RefreshCommand => "RefreshDashboard";
    }
}
