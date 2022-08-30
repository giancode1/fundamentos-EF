using Microsoft.EntityFrameworkCore;  //para DbContext, ahora ya no sale error
using proyectoef.Models;   //para Categoria, ahora ya no sale error

namespace proyectoef;

public class TareasContext: DbContext
{
//Crearemos un DBSet, es un set de datos del modelo
//basicamente representa una tabla dentro del contexto de ET
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options) :base(options)
    {

    }

}


