using Microsoft.Identity.Web;
using TeamsTabsBCE.Database.Core;
using TeamsTabsBCE.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration);

builder.Services.AddEntityFrameworkSqlite()
    .AddDbContext<BceDbContext>();

builder.Services.AddSignalR();

builder.Services.AddBusinessLogic();
builder.Services.AddServices();
builder.Services.AddDatabaseAccess();
builder.Services.AddDatabase();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapHub<SoftengDashboardHub>(SoftengDashboardHub.Url);

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseFileServer();

app.Run();