using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using StudentProjectManager.Auth;
using StudentProjectManager.Models.auth;
using StudentProjectManager.Repository;
using StudentProjectManager.Repository.Auth;
using System.Collections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add MongoDB services
var mongoDBSettings = builder.Configuration.GetSection("MongoDB");
string connectionString = mongoDBSettings["ConnectionString"];
string databaseName = mongoDBSettings["DatabaseName"];

var mongoClient = new MongoClient(connectionString);
builder.Services.AddSingleton(mongoClient.GetDatabase(databaseName));
builder.Services.AddTransient<TeamRepository>();
builder.Services.AddTransient<ProjectRepository>();
// end of mongoDB registration
builder.Services.AddScoped<IUserStore<ApplicationUser>, CustomUserStore>();
builder.Services.AddScoped<IRoleStore<ApplicationRole>, CustomRoleStore>();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddRoles<ApplicationRole>()
    .AddDefaultTokenProviders();


var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new ApplicationRole { Name = "Admin", NormalizedName = "ADMIN" }); // Using ApplicationRole here
    }

    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new ApplicationRole { Name = "User", NormalizedName = "USER" }); // Using ApplicationRole here
    }

    ApplicationUser adminUser = new ApplicationUser
    {
        UserName = "admin@admin.com",
        Email = "admin@admin.com",
        Roles = new List<string>() { "Admin" }
    };

    if (await userManager.FindByNameAsync(adminUser.UserName) == null)
    {
        await userManager.CreateAsync(adminUser, "Admin@123");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCustomAuthentication(); // Add your custom middleware here

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
