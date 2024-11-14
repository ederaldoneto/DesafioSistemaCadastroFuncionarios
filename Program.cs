using Microsoft.EntityFrameworkCore;
using TrilhaNetAzureDesafio.Context;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext para usar MySQL
builder.Services.AddDbContext<RHContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("ConexaoPadrao"),
        new MySqlServerVersion(new Version(8, 0, 27))
    ));

builder.Services.AddControllers();
// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();