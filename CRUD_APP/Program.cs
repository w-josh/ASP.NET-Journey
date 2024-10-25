using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CRUD_APP.Models;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

//WebApplication.CreateBuilder(args) is a built-in method provided by ASP.NET Core.
//It is used to set up and configure an ASP.NET Core application.

//Creates a WebApplicationBuilder instance: The method returns a WebApplicationBuilder object (which is what builder is),
//and this object is used to configure services and middleware for your app
// The args parameter is typically passed from Main in the Program.cs file and contains any command-line arguments passed when the app is run.
// In most cases, you can just pass args as they are, even if you’re not working with any specific command-line arguments.

builder.Services.AddControllersWithViews();

//AddControllersWithViews adds services to the container

//builder.Services.AddControllersWithViews(). Services is a property of type IserviceCollection and is defined like this: public Microsoft.Extensions.DependencyInjection.IServiceCollection Services { get; }
//AddControllersWithViews() is actually an extension method defined like this: public static IMvcBuilder AddControllersWithViews (this IServiceCollection services)
// this IServiceCollection services: This indicates that AddControllersWithViews() is an extension method for the IServiceCollection class. The this keyword is what turns this into an extension method.

//Configure the Database context. This is where we call the DbContext in the AppDbContext for configuring options

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),new MySqlServerVersion(new Version(7,0,0))));

// "DefaultConnection" is the setting in the appsettings.json. 
// MySqlServerVersion and Version are objects sent to the dbContext as options for configuration.
//Lambda operators (=>) in C# are a way to perform a method without giving it a name. Like an anonymous function.


var app = builder.Build();

//configure HTTP requests:

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{Id?}");

app.Run();