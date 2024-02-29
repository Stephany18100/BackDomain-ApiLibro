using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using WepApi.Services.IServices;
using WepApi.Services.Services;

namespace WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrestamosController: ControllerBase
    {
        private readonly IPrestamoServices _prestamoServices;
        public PrestamosController(IPrestamoServices prestamoServices)
        {

            _prestamoServices = prestamoServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrestamos()
        {
            return Ok(await _prestamoServices.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPrestamo(int id)
        {
            return Ok(await _prestamoServices.GetbyId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PrestamoResponse i)
        {

            return Ok(await _prestamoServices.Create(i));

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] PrestamoResponse i, int id)
        {
            return Ok(await _prestamoServices.Update(i, id));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _prestamoServices.Delete(id));
        }

    }
}
