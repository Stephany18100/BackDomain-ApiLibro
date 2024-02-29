using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using WepApi.Services.IServices;
using WepApi.Services.Services;

namespace WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrosController: ControllerBase
    {
        private readonly ILibroServices _librosServices;
        public LibrosController(ILibroServices libroServices)
        {

            _librosServices = libroServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLibros()
        {
            return Ok(await _librosServices.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLibro(int id)
        {
            return Ok(await _librosServices.GetbyId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LibroResponse i)
        {

            return Ok(await _librosServices.Create(i));

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] LibroResponse i, int id)
        {
            return Ok(await _librosServices.Update(i, id));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _librosServices.Delete(id));
        }
    }
}
