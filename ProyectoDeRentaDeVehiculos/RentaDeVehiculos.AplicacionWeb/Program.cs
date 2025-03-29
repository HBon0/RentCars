using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using RentaDeVehiculos.LogicaDeNegocio;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.AccesoDatos.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddBusinessLogicServices(builder.Configuration);

// Configurar autenticación con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie((o) =>
    {
        o.LoginPath = new PathString("/User/login");
        o.AccessDeniedPath = new PathString("/User/login");
        o.ExpireTimeSpan = TimeSpan.FromSeconds(8);
        o.SlidingExpiration = true;
        o.Cookie.HttpOnly = true;
    });

// Inyección de dependencias para repositorio genérico
builder.Services.AddScoped(typeof(IEfRepositorio<>), typeof(EfRepositorio<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
