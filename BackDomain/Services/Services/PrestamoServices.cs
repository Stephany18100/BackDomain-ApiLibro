using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WepApi.Context;
using WepApi.Services.IServices;

namespace WepApi.Services.Services
{
    public class PrestamoServices : IPrestamoServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;

        public PrestamoServices(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<Response<Prestamo>> Create(PrestamoResponse request)
        {
            try
            {
                Prestamo prestamo = new Prestamo()
                {
                    FKCodigoLibro = request.FKCodigoLibro,
                    FKCodigoUsuario = request.FKCodigoUsuario,
                    FechaSalida = request.FechaSalida,
                    FechaMaximaDevolver = request.FechaMaximaDevolver,
                    FechaDevolucion = request.FechaDevolucion
                };

                _context.Prestamos.Add(prestamo);
                await _context.SaveChangesAsync();

                return new Response<Prestamo>(prestamo);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        public async Task<Response<Prestamo>> Delete(int id)
        {
            try
            {
                Prestamo prestamo = _context.Prestamos.Find(id);

                _context.Prestamos.Remove(prestamo);

                await _context.SaveChangesAsync();

                Mensaje = "Se elimino correctamente";

                return new Response<Prestamo>(prestamo, Mensaje);

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        public async Task<Response<List<Prestamo>>> GetAll()
        {
            try
            {
                var response = await _context.Prestamos.ToListAsync();

                if (response.Count > 0)
                {
                    return new Response<List<Prestamo>>(response);
                }
                else
                {
                    Mensaje = "No se encontro ningun registro";
                    return new Response<List<Prestamo>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }

        public async Task<Response<Prestamo>> GetbyId(int id)
        {
            try
            {
                var response = await _context.Prestamos.FirstOrDefaultAsync(x => x.NumeroPedido == id);

                if (response != null)
                {
                    return new Response<Prestamo>(response);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Prestamo>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }

        public async Task<Response<Prestamo>> Update(PrestamoResponse request, int id)
        {
            try
            {
                var response = _context.Prestamos.Find(id);

                response.FKCodigoLibro = request.FKCodigoLibro;
                response.FKCodigoUsuario = request.FKCodigoUsuario;
                response.FechaSalida = request.FechaSalida;
                response.FechaMaximaDevolver = request.FechaMaximaDevolver;
                response.FechaDevolucion = request.FechaDevolucion;

                _context.Entry(response).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new Response<Prestamo>(response);

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }
    }
}
