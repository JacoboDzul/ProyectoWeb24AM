using ProyectoWeb24AM.Models.Entities;

namespace ProyectoWeb24AM.Services.IServices
{
    public interface ILibroServices
    {
        public Task<List<Libro>> GetLibros();
        public Task<Libro> GetByIdLibro(int id);
        public Task<Libro> CrearLibro(Libro i);
        public bool EliminarLibro(int id);
        public Task<Libro> EditarLibro(Libro O);
    }
}
