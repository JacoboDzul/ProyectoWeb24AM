using Microsoft.EntityFrameworkCore;
using ProyectoWeb24AM.Context;
using ProyectoWeb24AM.Models.Entities;
using ProyectoWeb24AM.Services.IServices;

namespace ProyectoWeb24AM.Services.Service
{
    public class RolServices:IRolServices
    {
        private readonly ApplicationDBContext _context;

        public RolServices(ApplicationDBContext context)
        {
           _context = context;  
        }

        public async Task<List<Rol>> GetAll()
        {
            try
            {
                var response = await _context.Roles.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Rol> GetByIdRol(int id)
        {
            try
            {
                //Articulo response = await _context.Articulo.FindAsync(id);
                Rol response = await _context.Roles.FirstOrDefaultAsync(x => x.PKRol == id);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }

        public async Task<Rol> CrearRol(Rol i)
        {
            try
            {
                Rol request = new Rol()
                {
                    Nombre = i.Nombre,
                    PKRol = i.PKRol,
                };
                var result = await _context.Roles.AddAsync(request);
                _context.SaveChanges();
                return request;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public bool EliminarRol(int id)
        {
            try
            {
                Rol RolesToDelete = _context.Roles.Find(id);

                if (RolesToDelete != null)
                {
                    var res = _context.Roles.Remove(RolesToDelete);
                    _context.SaveChanges();
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
        public async Task<Rol> EditarRol(Rol O)
        {
            try
            {

                Rol rol = _context.Roles.Find(O.PKRol);

                rol.Nombre = O.Nombre;
                rol.PKRol = O.PKRol;

                _context.Entry(rol).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return rol;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }

    }
}
