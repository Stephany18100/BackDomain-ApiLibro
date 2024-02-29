using Domain.Dto;
using Domain.Entities;

namespace WepApi.Services.IServices
{
    public interface ILibroServices
    {
        public Task<Response<List<Libro>>> GetAll();
        public Task<Response<Libro>> GetbyId(int id);
        public Task<Response<Libro>> Create(LibroResponse request);
        public Task<Response<Libro>> Update(LibroResponse request, int id);
        public Task<Response<Libro>> Delete(int id);
    }
}
