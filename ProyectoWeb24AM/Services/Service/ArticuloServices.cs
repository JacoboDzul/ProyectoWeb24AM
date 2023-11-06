using Microsoft.EntityFrameworkCore;
using ProyectoWeb24AM.Context;
using ProyectoWeb24AM.Models.Entities;
using ProyectoWeb24AM.Services.IServices;

namespace ProyectoWeb24AM.Services.Service
{
    public class ArticuloServices : IArticuloServices
    {
        private readonly ApplicationDBContext _context;

        public ArticuloServices(ApplicationDBContext context)
            
        {
            _context=context; //variable privada
        }
        public async Task<List<Articulo>> GetArticulos()
        {
            try
            {
                List<Articulo> articulos = await _context.Articulo.ToListAsync();
                return articulos;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }

        }

        public async Task<Articulo> GetByIdArticulo(int id)
        {
            try
            {
                //Articulo response = await _context.Articulo.FindAsync(id);
                Articulo response = await _context.Articulo.FirstOrDefaultAsync(x => x.PKArticulo == id);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Articulo> CrearArticulo(Articulo i)
        {
            try
            {
                Articulo request = new Articulo()
                {
                    Nombre = i.Nombre,
                    Descripcion = i.Descripcion,
                    Precio = i.Precio,
                };
                var result =  _context.Articulo.Add(request);
                await _context.SaveChangesAsync();
                return request;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }

        
    }
}
