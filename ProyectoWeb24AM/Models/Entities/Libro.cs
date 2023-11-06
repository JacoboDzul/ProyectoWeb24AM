using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb24AM.Models.Entities
{
    public class Libro
    {
        [Key]
        public int PKLibro { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Images { get; set; }
    }
}
