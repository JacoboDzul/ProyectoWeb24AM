using ProyectoWeb24AM.Models.Entities;

namespace ProyectoWeb24AM.Services.IServices
{
    public interface IRolServices
    {
        public Task<List<Rol>> GetAll();
        public Task<Rol> GetByIdRol(int id);
        public Task<Rol> CrearRol(Rol i);
        public bool EliminarRol(int id);
        public Task<Rol> EditarRol(Rol O);
    }
}
