using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WepApi.Context;
using WepApi.Services.IServices;

namespace WepApi.Services.Services
{
    public class LibroServices : ILibroServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;

        public LibroServices(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<Response<Libro>> Create(LibroResponse request)
        {
            try
            {
                Libro libro = new Libro()
                {
                    NombreLibro = request.NombreLibro,
                    Editorial = request.Editorial,
                    Autor = request.Autor,
                    Genero = request.Genero,
                    PaisAutor = request.PaisAutor,
                    NumeroDePaginas = request.NumeroDePaginas,
                    AnioDeEdicion = request.AnioDeEdicion,
                    Precio = request.Precio
                };

                _context.Libros.Add(libro);
                await _context.SaveChangesAsync();

                return new Response<Libro>(libro);
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        public async Task<Response<Libro>> Delete(int id)
        {
            try
            {
                Libro libro = _context.Libros.Find(id);

                _context.Libros.Remove(libro);

                await _context.SaveChangesAsync();

                Mensaje = "Se elimino correctamente";

                return new Response<Libro>(libro, Mensaje);

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        public async Task<Response<List<Libro>>> GetAll()
        {
            try
            {
                var response = await _context.Libros.ToListAsync();

                if (response.Count > 0)
                {
                    return new Response<List<Libro>>(response);
                }
                else
                {
                    Mensaje = "No se encontro ningun registro";
                    return new Response<List<Libro>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }

        public async Task<Response<Libro>> GetbyId(int id)
        {
            try
            {
                var response = await _context.Libros.FirstOrDefaultAsync(x => x.CodigoLibro == id);

                if (response != null)
                {
                    return new Response<Libro>(response);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Libro>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }

        public async Task<Response<Libro>> Update(LibroResponse request, int id)
        {
            try
            {
                var response = _context.Libros.Find(id);

                response.NombreLibro = request.NombreLibro;
                response.Editorial = request.Editorial;
                response.Autor = request.Autor;
                response.Genero = request.Genero;
                response.PaisAutor = request.PaisAutor;
                response.NumeroDePaginas = request.NumeroDePaginas;
                response.AnioDeEdicion = request.AnioDeEdicion;
                response.Precio = request.Precio;

                _context.Entry(response).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new Response<Libro>(response);

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }
    }
}
