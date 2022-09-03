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
        //crear data inicial: crearemos nueva colección de Categoria
        List<Categoria> categoriasInit = new List<Categoria>();
        //agregamos nuevo obj a categoriasInit
        categoriasInit.Add(new Categoria() {CategoriaId = Guid.Parse("4e26179c-6a70-41bc-8e78-69c6b77cb98a"), Nombre = "Actividades pendientes", Peso = 20 });
        categoriasInit.Add(new Categoria() {CategoriaId = Guid.Parse("4e26179c-6a70-41bc-8e78-69c6b77cb902"), Nombre = "Actividades personales", Peso = 50 });
        categoriasInit.Add(new Categoria() {CategoriaId = Guid.Parse("4e26179c-6a70-41bc-8e78-69c6b77cb903"), Nombre = "Actividades laborales", Peso = 70 });
        
        //diseñamos el modelo de categorias:
        modelBuilder.Entity<Categoria>(categoria=> 
        {
            categoria.ToTable("Categoria"); //puede especificar el nombre, las tablas en singular
            
            categoria.HasKey(p=> p.CategoriaId);

            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            
            categoria.Property(p=> p.Descripcion).IsRequired(false);

            categoria.Property(p=> p.Peso);
            
            //recibe un vector de categorias
            categoria.HasData(categoriasInit);

        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("4e26179c-6a70-41bc-8e78-69c6b77cb910"), CategoriaId = Guid.Parse("4e26179c-6a70-41bc-8e78-69c6b77cb98a") , PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios públicos", FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("4e26179c-6a70-41bc-8e78-69c6b77cb911"), CategoriaId = Guid.Parse("4e26179c-6a70-41bc-8e78-69c6b77cb902") , PrioridadTarea = Prioridad.Baja, Titulo = "Terminar de ver pelicula en Netflix", FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("4e26179c-6a70-41bc-8e78-69c6b77cb912"), CategoriaId = Guid.Parse("4e26179c-6a70-41bc-8e78-69c6b77cb903") , PrioridadTarea = Prioridad.Alta, Titulo = "Terminar Reporte", FechaCreacion = DateTime.Now });
        //diseñamos el modelo de tareas:
        modelBuilder.Entity<Tarea>(tarea=> 
        {
            tarea.ToTable("Tarea"); 
            tarea.HasKey(p=> p.TareaId);
            
            //existe una propiedad dentro de Tarea que se llama Categoria, esta puede tener relacion con multiples(WithMany) Tareas, existe una clave foranea llamada CategoriaId
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);
            
            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
            
            tarea.Property(p=> p.Descripcion).IsRequired(false);
            
            tarea.Property(p=> p.PrioridadTarea);
            
            tarea.Property(p=> p.FechaCreacion);
            
            tarea.Ignore(p=> p.Resumen);
            
            tarea.HasData(tareasInit);

        });
    }

}


