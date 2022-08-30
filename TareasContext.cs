using Microsoft.EntityFrameworkCore;  //para DbContext, ahora ya no sale error
using proyectoef.Models;   //para Categoria, ahora ya no sale error

namespace proyectoef;

public class TareasContext: DbContext  // Heredamos de la clase DbContext
{
//Crearemos un DBSet, es un set de datos del modelo
//basicamente representa una tabla dentro del contexto de EF
//Modelos : <Categoria> <Tarea>
//Colecciones dentro del DbSet, dentro del contexto de EF se llaman de manera plural: Catgorias, Tareas
    public DbSet<Categoria> Categorias {get;set;}  
    public DbSet<Tarea> Tareas {get;set;}

    // "base" es el metodo base del constructor de EF
    public TareasContext(DbContextOptions<TareasContext> options) :base(options)
    {
        

    }

}


