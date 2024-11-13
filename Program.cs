using Plantas.Models;
using Plantas.Repositories;
using Plantas.Repositories.Interfaces;
using Plantas.Services;
using Plantas.Utilities;

var builder = WebApplication.CreateBuilder(args);
var configure = builder.Configuration;

builder.Services.Configure<MongoConnections>(builder.Configuration.GetSection("Base"));


builder.Services.AddScoped<TargetService>();
builder.Services.AddScoped<DataInterface<Plant>, DataCollection>();

// builder.Services.AddScoped<FamilyService>();
// builder.Services.AddScoped<FamilyInterface<Family>, FamilyCollection>();
// builder.Services.AddScoped<VerInterface, FamilyCollection>();

builder.Services.AddScoped<FamilyService>(); // Registrar FamilyService
builder.Services.AddScoped<FamilyInterface<Family>, FamilyCollection>(); // Registrar la interfaz con su implementación
builder.Services.AddScoped<VerInterface, FamilyCollection>();

builder.Services.AddScoped<ImageUtility>();
builder.Services.AddSingleton<Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
