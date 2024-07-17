using api.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // Certifique-se de usar Pomelo

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi encontrada ou está vazia.");
}

// Adicione o serviço do contexto de banco de dados
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 26)) // Especifique a versão do MySQL Server
    )
    .EnableSensitiveDataLogging() // Adicione isso para logs mais detalhados
    .EnableDetailedErrors()       // Adicione isso para logs mais detalhados
);

var app = builder.Build();

// Configure o pipeline HTTP
app.Run();
