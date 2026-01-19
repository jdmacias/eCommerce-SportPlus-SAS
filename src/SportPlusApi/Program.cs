using Microsoft.EntityFrameworkCore;
using SportPlusApi.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Agrega esta línea para que el sistema reconozca tus Controllers
builder.Services.AddControllers();

// No olvides agregar este using arriba del todo:
// using Microsoft.EntityFrameworkCore;
// using SportPlusApi.Data;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=SportPlus.db"));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Comentamos la redirección HTTPS para evitar el error amarillo que te salió antes
// app.UseHttpsRedirection(); 

// 2. Agrega esta línea para que las rutas (como /api/productos) funcionen
app.MapControllers();

// Podemos dejar o quitar lo del WeatherForecast, no afectará a tus productos
app.MapGet("/weatherforecast", () => {
    return "El clima está bien, ¡pero tus productos son mejores!";
});

app.Run();