using Microsoft.EntityFrameworkCore;
using ProyectoWeb24AM.Context;
using ProyectoWeb24AM.Models.Entities;
using ProyectoWeb24AM.Services.IServices;

namespace ProyectoWeb24AM.Services.Service
{
    public class LibroServices : ILibroServices
    {
        private readonly ApplicationDBContext _context;

        public LibroServices(ApplicationDBContext context)
        {
            _context = context; //variable privada
        }
        public async Task<List<Libro>> GetLibros()
        {
            try
            {
                List<Libro> libros = await _context.Libros.ToListAsync();
                return libros;
              

            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }

        }
        public async Task<Libro> GetByIdLibro(int id)
        {
            try
            {
                //Articulo response = await _context.Articulo.FindAsync(id);
                Libro response = await _context.Libros.FirstOrDefaultAsync(x => x.PKLibro == id);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }

        public async Task<Libro> CrearLibro(Libro i)
        {
            try
            {
                Libro request = new Libro()
                {
                    Titulo = i.Titulo,
                    Descripcion = i.Descripcion,
                    Images = i.Images,
                };
                var result = await _context.Libros.AddAsync(request);
                _context.SaveChanges();
                return request;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }

        public bool EliminarLibro(int id)
        {
            try
            {
                Libro libroToDelete = _context.Libros.Find(id);

                if (libroToDelete != null)
                {
                    var res = _context.Libros.Remove(libroToDelete);
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
        public async Task<Libro> EditarLibro(Libro O)
        {
            try
            {

                Libro libro = _context.Libros.Find(O.PKLibro);

                libro.Titulo = O.Titulo;
                libro.Descripcion = O.Descripcion;
                libro.Images = O.Images;

                _context.Entry(libro).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return libro;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
    }
}
