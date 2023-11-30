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

        [NotMapped]
        [Display(Name = "Imagen")]

        public IFormFile Img { get; set; }

        public string UrlImagenPath { get; set; }

        [ForeignKey("Articulo")]
        public int? FkArticulo { get; set; }
        public Articulo Articulo { get; set; }


        


    }
}
