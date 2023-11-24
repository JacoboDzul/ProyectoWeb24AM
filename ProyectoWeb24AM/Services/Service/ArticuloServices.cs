﻿using Microsoft.EntityFrameworkCore;
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
                var result =  await _context.Articulo.AddAsync(request);
                               _context.SaveChanges();
                return request;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }

        public bool EliminarArticulo(int id)
        {
            try
            {
                Articulo articuloToDelete = _context.Articulo.Find(id);
               
                if(articuloToDelete != null)
                {
                    var res = _context.Articulo.Remove(articuloToDelete);
                    _context.SaveChanges();
                    return true;
                }
                else

                {
                    throw new Exception("El artículo no existe");
                }
                    
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Articulo> EditarArticulo(Articulo O)
        {
            try
            {

                Articulo articulo = _context.Articulo.Find(O.PKArticulo);

                articulo.Nombre = O.Nombre;
                articulo.Descripcion = O.Descripcion;
                articulo.Precio = O.Precio;

                _context.Entry(articulo).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return articulo;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
    }
}
