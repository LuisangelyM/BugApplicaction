using BugApplication.Data;
using BugApplication.Services;
using Microsoft.EntityFrameworkCore; // NUEVO: Necesario para SQL

var builder = WebApplication.CreateBuilder(args);

// --- CONFIGURACIÓN DE SERVICIOS ---
builder.Services.AddControllers();

// NUEVO: Estas dos líneas son las que activan la página de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registramos la base de datos
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<BugService>();

// CONFIGURAR CORS
builder.Services.AddCors(options => {
    options.AddPolicy("PermitirTodo", policy => {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// --- CONFIGURACIÓN DEL PIPELINE ---

// NUEVO: Esto activa la interfaz visual de Swagger para que no te dé 404
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("PermitirTodo");
app.UseHttpsRedirection(); // NUEVO: Por seguridad de la API
app.MapControllers();

app.Run();