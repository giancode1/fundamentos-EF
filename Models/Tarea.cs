using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoef.Models;

public class Tarea
{
    // [Key]
    public Guid TareaId {get; set;}
    
    //clave foranea, relacion entre una tabla y otra
    //en CategoriaId se guardaran los id que se creen en la tabla Categorias
    // [ForeignKey("CategoriaId")]
    public Guid CategoriaId {get; set;}

    // [Required]
    // [MaxLength(200)]
    public string Titulo {get; set;}

    public string Descripcion {get; set;}

    public Prioridad PrioridadTarea {get; set;}

    public DateTime FechaCreacion {get; set;}

    public virtual Categoria Categoria {get; set;}

    // que no exista en la db, calculado
    // en el momento que se haga el mapeo de nuestro contexto, el omita este campo
    // [NotMapped] 
    public string Resumen {get; set;}

}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}