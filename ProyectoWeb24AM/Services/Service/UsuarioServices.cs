using Microsoft.EntityFrameworkCore;
using ProyectoWeb24AM.Context;
using ProyectoWeb24AM.Models.Entities;
using ProyectoWeb24AM.Services.IServices;

namespace ProyectoWeb24AM.Services.Service
{
    public class UsuarioServices: IUsuarioServices
    {
        private readonly ApplicationDBContext _services;

        public UsuarioServices (ApplicationDBContext services)
        {
            _services = services;
        }

        public async Task<List<Usuario>> GetAll()
        {
            try
            {
                var response = await _services.Usuarios.Include(Y=>Y.Roles).ToListAsync();
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Usuario> GetByIdUsuario(int id)
        {
            try
            {
                //Articulo response = await _context.Articulo.FindAsync(id);
                Usuario response = await _services.Usuarios.FirstOrDefaultAsync(x => x.PKUsuario== id);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }

        public async Task<Usuario> Crear(Usuario i)
        {
            try
            {
                Usuario request = new Usuario()
                {
                    Nombre = i.Nombre,
                    Apellido = i.Apellido,
                    UserName = i.UserName,
                    Password = i.Password,
                    FKRol = i.FKRol,
                };
                var response= await _services.Usuarios.AddAsync(request);
                _services.SaveChanges();
                return request;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarUsuario(int id)
        {
            try
            {
                Usuario UserToDelete = _services.Usuarios.Find(id);

                if (UserToDelete != null)
                {
                    var res = _services.Usuarios.Remove(UserToDelete);
                    _services.SaveChanges();
                    return true;
                }
                else

                {
                    throw new Exception("El libro no existe");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Usuario> EditarUser(Usuario O)
        {
            try
            {

                Usuario usuario = _services.Usuarios.Find(O.PKUsuario);

                usuario.Nombre = O.Nombre;
                usuario.Apellido = O.Apellido;
                usuario.UserName = O.UserName;
                usuario.Roles = O.Roles;    
                usuario.FKRol=O.FKRol;
               

                _services.Entry(usuario).State = EntityState.Modified;
                await _services.SaveChangesAsync();
                return usuario;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
    }
}
