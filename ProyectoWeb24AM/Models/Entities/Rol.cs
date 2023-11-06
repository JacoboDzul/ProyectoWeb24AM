using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb24AM.Models.Entities
{
    public class Rol
    {
        [Key]
        public int PKRol {  get; set; }
        public string Nombre { get; set; }
    }
}
