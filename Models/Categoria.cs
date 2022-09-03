using System.ComponentModel.DataAnnotations;  //para que no de error [Key]
using System.Text.Json.Serialization;

namespace proyectoef.Models;

public class Categoria
{
    //Data notations: [Key], [Required] , etc
    //[Key] //forzamos cuando se cree la tabla Categoria, utilice CategoriaId como clave
    public Guid CategoriaId {get; set;}

    // [Required]
    // [MaxLength(150)]
    public string Nombre {get; set;}

    public string Descripcion {get; set;}
    
    public int Peso {get; set;}

    [JsonIgnore] //cuando retorne los datos, NO traer la coleccion de Tareas
    public virtual ICollection<Tarea> Tareas {get; set;}
}
