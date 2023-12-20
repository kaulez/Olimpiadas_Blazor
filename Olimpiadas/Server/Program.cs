using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Olimpiadas.Server.Data;
using Olimpiadas.Server.Models;
using Microsoft.AspNetCore.Identity;
using Olimpiadas.Server.Areas.Identity.Data;
using Entity_Layer.DbContextApplication;
using Data_Layer.Interfaces;
using Data_Layer.Repositories;
using Logic_Layer.Interfaces;
using Logic_Layer.CampusLogic;
using Logic_Layer.SportComplexLogics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionStringApplication = builder.Configuration.GetConnectionString("ApplicationConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connectionStringApplication));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


//Inyeccion de dependencias para los repositorios que seran llamados en logica, esto se puede sacar a una capa aparte pero lo he dejado aca por practicidad 
builder.Services.AddScoped<ICampusRepository,CampusRepository>();
builder.Services.AddScoped<ISportComplexRepository, SportComplexRepository>();

//Inyeccion de dependencias para la logica que seran llamados en presentacion

builder.Services.AddScoped<ICampusLogic, CampusLogic>();
builder.Services.AddScoped<ISportComplexLogic, SportComplexLogic>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
