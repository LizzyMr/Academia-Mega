using Microsoft.AspNetCore.Mvc;
using PrimeraAPI.Data;
using PrimeraAPI.Models;

namespace PrimeraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //api/productos
    public class ProductosController : ControllerBase
    {
        //Aquí sería la lectura de datos en BD
        private readonly ProductoService _service;
        public ProductosController(ProductoService service)
        {
            _service = service;
        }

        /*
                - CREATE -
        */
        [HttpPost] // POST /api/productos
        public ActionResult<Producto> Create(Producto nuevo)
        {
            return NoContent();
        }

        /*
                - READ -
        */
        [HttpGet] //GET /api/productos
        public async Task<IActionResult> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")] //GET /api/productos/1
        public ActionResult<Producto> GetById(int id)
        {
            return NoContent();
        }

        /*
                - UPDATE -
        */
        [HttpPut("{id}")] // PUT / api/productos/1
        public IActionResult Update(int id, Producto actualizado)
        {
            return NoContent();
        }

        /*
                - DELETE -
        */
        [HttpDelete("{id}")] // DELETE /api/productos/1
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }

    //Modelo producto
    public class Producto
    {
        public int id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }  
    }
}

