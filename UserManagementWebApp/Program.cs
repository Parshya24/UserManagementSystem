using Flurl.Http.Configuration;
using UserManagementWebApp.Repositories;
using UserManagementWebApp.Services;
using UserManagementWebApp.Services.IServices;
using  CommonClassLibrary.Dto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IUserManagementRepository, UserManagementRepository>();
builder.Services.AddSingleton<IUserManagementService, UserManagementService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserManagement}/{action=Index}/{id?}");

app.Run();
