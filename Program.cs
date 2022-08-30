using Microsoft.AspNetCore.Mvc;       //FromServices
using Microsoft.EntityFrameworkCore;
using proyectoef;   //el namespace de TareasContext

var builder = WebApplication.CreateBuilder(args);

//
builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

var app = builder.Build(); //la aplicacion se construye

app.MapGet("/", () => "Hello World!");

// FromServices : recibimos el contexto de EF
// dbContext : nombre de la variable que recibe el contexto
app.MapGet("/dbconexion", async([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();  
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
    // IsInMemory: da True/False si la db se creo con el EnsureCreated
});

app.Run();
