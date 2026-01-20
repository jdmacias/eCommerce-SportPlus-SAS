using Microsoft.EntityFrameworkCore;
using SportPlusApi.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Servicios básicos
builder.Services.AddControllers();

// 2. CONFIGURACIÓN DE SWAGGER
// Solo dejamos estas dos para la documentación
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Tu configuración de SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=SportPlus.db"));

// --- ELIMINAMOS builder.Services.AddOpenApi() para evitar el choque ---

var app = builder.Build();

// 3. ACTIVACIÓN DE LA INTERFAZ VISUAL
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // --- ELIMINAMOS app.MapOpenApi() para evitar el choque ---
}

// Mantenemos tu configuración de seguridad actual
// app.UseHttpsRedirection(); 

app.MapControllers();

app.MapGet("/weatherforecast", () => {
    return "El clima está bien, ¡pero tus productos son mejores!";
});

app.Run();