using Microsoft.AspNetCore.Mvc;
//using Asp.Versioning;

[ApiController]
//[ApiVersion("1.0")]

[Route("api/[controller]")] //api/productos
//[Route("api/v{version:apiVersion}/[controller]")] //api/productos
public class ProductosController : ControllerBase
{

//Aquí sería la lectura de datos en BD
    public static readonly List<Producto> _datos = new()
    {
        new Producto {id = 1, Nombre = "iPhone 16", Precio = 19999.0m },
        new Producto {id = 2, Nombre = "Galaxy S25 Ege", Precio = 21599.0m }
    };

    /*
             - CREATE -
    */
    [HttpPost] // POST /api/productos
    public ActionResult<Producto> Create(Producto nuevo)
    {
        nuevo.id = _datos.Max(p => p.id) + 1; 
        _datos.Add(nuevo);
        return CreatedAtAction(nameof(GetById), new {id = nuevo.id}, nuevo);
    }

    /*
               - READ -
    */
    [HttpGet] //GET /api/productos
    public ActionResult<IEnumerable<Producto>> GetAll()
    {
        return Ok(_datos);
    }

    [HttpGet("{id}")] //GET /api/productos/1
    public ActionResult<Producto> GetById(int id)
    {
        var product = _datos.FirstOrDefault(p => p.id == id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    /*
               - UPDATE -
    */
    [HttpPut("{id}")] // PUT / api/productos/1
    public IActionResult Update(int id, Producto actualizado)
    {
        var product = _datos.FirstOrDefault(p => p.id == id);
        if (product == null) return NotFound();

        product.Nombre = actualizado.Nombre;
        product.Precio = actualizado.Precio;

        return NoContent();
    }

    /*
               - DELETE -
    */
    [HttpDelete("{id}")] // DELETE /api/productos/1
    public IActionResult Delete(int id)
    {
        var product = _datos.FirstOrDefault(p => p.id == id);
        if (product == null) return NotFound();

        _datos.Remove(product);
        return Ok("El valor se ha eliminado correctamente.");
    }
}

//Modelo producto
public class Producto
{
    public int id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }  
}