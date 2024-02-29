using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WepApi.Context;
using WepApi.Services.IServices;

namespace WepApi.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;

        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<Response<List<Usuario>>> GetAll()
        {
            try
            {
                var response = await _context.Usuarios.ToListAsync();

                if (response.Count > 0)
                {

                    return new Response<List<Usuario>>(response);
                }
                else
                {
                    Mensaje = "No se encontro ningun registro";
                    return new Response<List<Usuario>>(Mensaje);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error: " + ex.Message);
            }

        }

        public async Task<Response<Usuario>> GetbyId(int id)
        {
            try
            {
                var response = await _context.Usuarios.FirstOrDefaultAsync(x => x.CodigoUsuario == id);

                if (response != null)
                {
                    return new Response<Usuario>(response);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Usuario>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }

        }


        public async Task<Response<Usuario>> Create(UsuarioResponse request)
        {

            try
            {
                Usuario user = new Usuario()
                {
                    NombreUsuario = request.NombreUsuario,
                    Apellidos = request.Apellidos,
                    DNI = request.DNI,
                    Domicilio = request.Domicilio,
                    Ciudad = request.Ciudad,
                    Estado = request.Estado,
                    FechaNacimiento = request.FechaNacimiento

                };

                _context.Usuarios.Add(user);
                await _context.SaveChangesAsync();


                return new Response<Usuario>(user);
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }


        public async Task<Response<Usuario>> Update(UsuarioResponse request, int id)
        {
            try
            {
                var response = _context.Usuarios.Find(id);

                response.NombreUsuario = request.NombreUsuario;
                response.Apellidos = request.Apellidos;
                response.DNI = request.DNI;
                response.Domicilio = request.Domicilio;
                response.Ciudad = request.Ciudad;
                response.Estado = request.Estado;
                response.FechaNacimiento = request.FechaNacimiento;

                _context.Entry(response).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new Response<Usuario>(response);
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }
        public async Task<Response<Usuario>> Delete(int id)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Find(id);
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                Mensaje = "Se elimino correctamente";
                return new Response<Usuario>(usuario, Mensaje);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

    }
}
