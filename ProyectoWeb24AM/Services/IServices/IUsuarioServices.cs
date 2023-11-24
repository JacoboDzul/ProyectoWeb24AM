using ProyectoWeb24AM.Models.Entities;

namespace ProyectoWeb24AM.Services.IServices
{
    public interface IUsuarioServices
    {
        public Task<List<Usuario>> GetAll();
        public Task<Usuario> GetByIdUsuario(int id);
        public Task<Usuario> Crear(Usuario i);
        public bool EliminarUsuario(int id);
        public Task<Usuario> EditarUser(Usuario O);
    }
}
