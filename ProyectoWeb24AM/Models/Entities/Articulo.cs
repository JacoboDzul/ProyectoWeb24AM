using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb24AM.Models.Entities
{
    public class Articulo
    {
        [Key]
        public int PKArticulo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion {  get; set; }
        [Required]
        public decimal Precio { get; set; }
    }
}
