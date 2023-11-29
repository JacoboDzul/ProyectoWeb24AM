using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWeb24AM.Models.Entities
{
    public class Promocion
    {
        [Key]
        public int PKPromocion { get; set; }
       
        [Required]
        public decimal Descuento { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [ForeignKey("Articulos")]
        public int? FkArticulo { get; set; }
        public Articulo Articulos { get; set; }


    }
}
