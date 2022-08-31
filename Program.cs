using Microsoft.AspNetCore.Mvc;       //FromServices
using Microsoft.EntityFrameworkCore;
using proyectoef;   //el namespace de TareasContext

var builder = WebApplication.CreateBuilder(args);

//db en memoria:
// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

//de en Sql Server:
// con pass:
//builder.Services.AddSqlServer<TareasContext>("Data Source=LAPTOP-2FO7TIND\\SQLEXPRESS;Initial Catalog=TareasDb;user id=sa;password=dominic");
// sin pass, con windows authentication:
builder.Services.AddSqlServer<TareasContext>("Data Source=(local); Initial Catalog= TareasDb;Trusted_Connection=True; Integrated Security=True");

var app = builder.Build(); //la aplicacion se construye

app.MapGet("/", () => "Hello World!");

// FromServices : recibimos el contexto de EF
// dbContext : nombre de la variable que recibe el contexto
app.MapGet("/dbconexion", async([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();  
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
    // IsInMemory: da True/False si la db se creo con el EnsureCreated
    //return Results.Ok("Base de datos en SQL Server: " + dbContext.Database.IsSqlServer());
});

app.Run();
