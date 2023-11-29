using ProyectoWeb24AM.Models.Entities;

namespace ProyectoWeb24AM.Services.IServices
{
    public interface IArticuloServices
    {
        //Todo método debe estar en una interfaz 
        public Task<List<Articulo>> GetArticulos();
        public Task<Articulo> GetByIdArticulo(int id);
        public Task<Articulo> CrearArticulo(Articulo i);
        public bool EliminarArticulo(int id);
        public Task<Articulo> EditarArticulo(Articulo O);
       
    }
}

