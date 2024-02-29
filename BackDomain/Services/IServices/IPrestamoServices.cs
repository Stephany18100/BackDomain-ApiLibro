using Domain.Dto;
using Domain.Entities;

namespace WepApi.Services.IServices
{
    public interface IPrestamoServices
    {
        public Task<Response<List<Prestamo>>> GetAll();
        public Task<Response<Prestamo>> GetbyId(int id);
        public Task<Response<Prestamo>> Create(PrestamoResponse request);
        public Task<Response<Prestamo>> Update(PrestamoResponse request, int id);
        public Task<Response<Prestamo>> Delete(int id);
    }
}
