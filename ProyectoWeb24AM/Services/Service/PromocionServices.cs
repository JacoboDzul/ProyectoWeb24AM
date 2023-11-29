using Microsoft.EntityFrameworkCore;
using ProyectoWeb24AM.Context;
using ProyectoWeb24AM.Models.Entities;
using ProyectoWeb24AM.Services.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoWeb24AM.Services.Service
{
    public class PromocionServices : IPromocionServices
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _webHost;
        private readonly IHttpContextAccessor _httpContext;

        public PromocionServices(ApplicationDBContext context, IHttpContextAccessor httpContext, IWebHostEnvironment webHost)
        {
            _httpContext = httpContext;
            _webHost = webHost;
            _context = context;
        }

        public async Task<List<Promocion>> GetPromotion()
        {
            try
            {
                List<Promocion> promotions = await _context.Promocion
                    .Include(p => p.Articulos)
                    .ToListAsync();

                return promotions;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }

        public async Task<Promocion> GetByIdPromotion(int id)
        {
            try
            {
                Promocion response = await _context.Promocion
                    .Include(p => p.Articulos) 
                    .FirstOrDefaultAsync(x => x.PKPromocion == id);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }

        public async Task<Promocion> CreatePromotion(Promocion i)
        {
            try
            {
                Promocion request = new Promocion()
                {
                    Descuento = i.Descuento,
                    FechaInicio = i.FechaInicio,
                    FechaFin = i.FechaFin,
                    FkArticulo = i.FkArticulo,
                };

                // Carga la propiedad de navegación Articulo antes de agregarla
                if (i.FkArticulo.HasValue)
                {
                    request.Articulos = await _context.Articulo.FindAsync(i.FkArticulo.Value);
                }

                var result = await _context.Promocion.AddAsync(request);
                _context.SaveChanges();
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }

        public bool EliminarPromotion(int id)
        {
            try
            {
                Promocion promotionToDelete = _context.Promocion.Find(id);

                if (promotionToDelete != null)
                {
                    var res = _context.Promocion.Remove(promotionToDelete);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("La promoción no existe");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }

        public async Task<Promocion> EditarPromotion(Promocion O)
        {
            try
            {
                Promocion promocion = _context.Promocion.Find(O.PKPromocion);

                promocion.Descuento = O.Descuento;
                promocion.FechaInicio = O.FechaInicio;
                promocion.FechaFin = O.FechaFin;

                _context.Entry(promocion).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return promocion;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }
    }
}
