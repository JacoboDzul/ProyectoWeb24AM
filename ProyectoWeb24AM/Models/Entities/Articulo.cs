using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb24AM.Models.Entities
{
    public class Articulo
    {
        [Key]
        public int PKArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion {  get; set; }
        public decimal Precio { get; set; }
    }
}
