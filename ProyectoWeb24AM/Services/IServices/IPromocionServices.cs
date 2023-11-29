using ProyectoWeb24AM.Models.Entities;

namespace ProyectoWeb24AM.Services.IServices
{
    public interface IPromocionServices
    {
        public Task<List<Promocion>> GetPromotion();
        public Task<Promocion> GetByIdPromotion(int id);
        public Task<Promocion> CreatePromotion(Promocion i);
        public bool EliminarPromotion(int id);
        public Task<Promocion> EditarPromotion(Promocion O);

    }
}
