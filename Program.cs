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
// builder.Services.AddSqlServer<TareasContext>("Data Source=(local); Initial Catalog= TareasDb;Trusted_Connection=True; Integrated Security=True");

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build(); //la aplicacion se construye

app.MapGet("/", () => "Hello World!");

// FromServices : recibimos el contexto de EF
// dbContext : nombre de la variable que recibe el contexto
app.MapGet("/dbconexion", async([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();  
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory() + ", "+ "Base de datos en SQL Server: " + dbContext.Database.IsSqlServer());
    // IsInMemory: da True/False si la db se creo con el EnsureCreated
    //return Results.Ok("Base de datos en SQL Server: " + dbContext.Database.IsSqlServer());
});

//[desde los servicios] trae-TareaConetxt nombre=dbContext
app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext)=>
{
    return Results.Ok(dbContext.Tareas);
});

//filtra datos con prioridad baja
app.MapGet("/api/tareas/bajas", async ([FromServices] TareasContext dbContext)=>
{
    return Results.Ok(dbContext.Tareas.Where(p => p.PrioridadTarea == proyectoef.Models.Prioridad.Baja));
});

//filtra datos con prioridad baja  e incliuye la Categoria(virtual)
app.MapGet("/api/tareas/bajas-extra", async ([FromServices] TareasContext dbContext)=>
{
    return Results.Ok(dbContext.Tareas.Include(proyectoef=>proyectoef.Categoria).Where(p => p.PrioridadTarea == proyectoef.Models.Prioridad.Baja));
});

//filtra en base a la prioridad
app.MapGet("/api/tareas/prioridad/{id}", async ([FromServices] TareasContext dbContext, int id) => {
    var data = dbContext.Tareas.Include(a => a.Categoria).Where(a => (int)a.PrioridadTarea == id);
    return Results.Ok(data);
});


app.Run();
