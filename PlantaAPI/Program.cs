using API.Models;
using Microsoft.EntityFrameworkCore;
using PlantaAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PlantaConnection")));
var app = builder.Build();

// Definição das rotas (métodos CRUD)
app.MapPost("/api/plantas/cadastrar", async (Planta planta, AppDataContext ctx) =>
{
    ctx.Plantas.Add(planta);
    await ctx.SaveChangesAsync();
    return Results.Created($"/api/plantas/{planta.IdPlanta}", planta);
});

// Outras rotas de consulta, atualização e exclusão podem ser adicionadas conforme o modelo fornecido

app.Run();
