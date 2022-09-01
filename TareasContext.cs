using Microsoft.EntityFrameworkCore;  //para DbContext, ahora ya no sale error
using proyectoef.Models;   //para Categoria, ahora ya no sale error

namespace proyectoef;

public class TareasContext: DbContext  // Heredamos de la clase DbContext
{
//Crearemos un DBSet, es un set de datos del modelo
//basicamente representa una tabla dentro del contexto de EF
//aqui los Modelos son: <Categoria> <Tarea>   "es decir entre< >"
//Colecciones dentro del DbSet, dentro del contexto de EF se llaman de manera plural: Catgorias, Tareas
    public DbSet<Categoria> Categorias {get;set;}   // <Modelo>
    public DbSet<Tarea> Tareas {get;set;}    // <Modelo>

    // "base" es el metodo base del constructor de EF
    public TareasContext(DbContextOptions<TareasContext> options) :base(options){}

    // override sobreescribe uno delos metodos internos de DbContext
    // este se invoca cuando esta diseñando la db
    // metodo override no puede ser publico
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //diseñamos el modelo de categorias:
        modelBuilder.Entity<Categoria>(categoria=> 
        {
            categoria.ToTable("Categoria"); //puede especificar el nombre, las tablas en singular
            
            categoria.HasKey(p=> p.CategoriaId);

            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            
            categoria.Property(p=> p.Descripcion);

        });

        //diseñamos el modelo de tareas:
        modelBuilder.Entity<Tarea>(tarea=> 
        {
            tarea.ToTable("Tarea"); 
            tarea.HasKey(p=> p.TareaId);
            
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);
            
            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
            
            tarea.Property(p=> p.Descripcion);
            
            tarea.Property(p=> p.PrioridadTarea);
            
            tarea.Property(p=> p.FechaCreacion);

        });
    }

}


