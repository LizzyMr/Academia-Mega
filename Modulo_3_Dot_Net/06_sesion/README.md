# Sesión 06: ASP.NET y C#

## Fecha: 19/05/2025

## Objetivos de la Sesión

- Introducción a ASP.NET y C#

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Funciones y métodos en C#
   - Arreglos y colecciones básicas
   - Manejo de errores y excepciones
   - Conceptos avanzados (enum y struct)
   - Introducción a la POO

## Ejercicios Realizados

### Ejercicio 06: Implementación de Métodos - Create, Read, Update.
### Tarea 06: Implementación del Método - Delete.

```c#
// program.cs
using PrimeraAPI.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<ProductoService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
```

```c#
// Producto.cs
namespace PrimeraAPI.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }  
    }
}
```

```c#
// ProductosControllers.cs
using System.Threading.Tasks;
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
        public async Task<IActionResult> Create(Producto nuevo)
        {
            var created = await _service.CreateAsync(nuevo);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
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
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        /*
                - UPDATE -
        */
        [HttpPut("{id}")] // PUT / api/productos/1
        public async Task<IActionResult> Update(int id, Producto actualizado)
        {
            var updated = await _service.UpdateAsync(id, actualizado);
            if (!updated) return NotFound();
            return NoContent();
        }

        /*
                - DELETE -
        */
        [HttpDelete("{id}")] // DELETE /api/productos/1
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
   
}
```

```c#
// ProductoService.cs
using Microsoft.Data.SqlClient;
using PrimeraAPI.Models;
using Microsoft.Extensions.Configuration;
//using System.Data.SqlClient;

namespace PrimeraAPI.Data
{
    public class ProductoService
    {
        private readonly string _connectionString;

        public ProductoService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("TiendaDB")
            ?? throw new InvalidOperationException("Cadena de conexión no encontrada.");
        }

        // Obtener todos los productos
        public async Task<List<Producto>> GetAllAsync()
        {
            var productList = new List<Producto>();
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand("SELECT * FROM Productos", conn);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                productList.Add(new Producto //
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Precio = reader.GetDecimal(2)
                });
            }

            return productList;
        }

        // Obtener un producto por ID
        public async Task<Producto?> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand(
                "SELECT * FROM Productos WHERE Id = @Id", conn
            );
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Producto
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Precio = reader.GetDecimal(2)
                };
            }
            return null;
        }

        // Crear un nuevo producto
        public async Task<Producto> CreateAsync(Producto producto)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand(
                "INSERT INTO Productos (Nombre, Precio) OUTPUT INSERTED.Id VALUES (@Nombre, @Precio)",
                conn
            );
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);

            var id = (int)await cmd.ExecuteScalarAsync()!;
            producto.Id = id;
            return producto;
        }

        // Actualizar un producto ya existente
        public async Task<bool> UpdateAsync(int id, Producto product)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand(
                "UPDATE Productos SET  Nombre = @Nombre, Precio = @Precio WHERE Id = @Id",
                conn
            );
            cmd.Parameters.AddWithValue("@Nombre", product.Nombre);
            cmd.Parameters.AddWithValue("@Precio", product.Precio);
            cmd.Parameters.AddWithValue("@Id", id);
            var afectedRows = await cmd.ExecuteNonQueryAsync();
            return afectedRows > 0;
        }

        // Eliminar un producto por Id
        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand(
                "DELETE FROM Productos WHERE Id = @Id",
                conn
            );
            cmd.Parameters.AddWithValue("@Id", id);
            var affectedRows = await cmd.ExecuteNonQueryAsync();
            return affectedRows > 0;
        }
    }
}
```

## Desafíos Encontrados

- **Sin Impedimentos:** Para esta actividad no tuve ningún problema. 

## Recursos Adicionales

- Curso completo programación C# en .Net y muchísimos más
- Programación en C de Cero a Experto con Estructuras de Datos
- C# Curso Completo para ser programador .NET
- Domina la Programacion C# con Visual Studio DESDE CERO
- Curso Completo de Programación C Sharp (C#)

## Próximos Pasos

- Continuar los avances en cursos de Udemy. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre C#.

---

*Entregable correspondiente a la Semana 10 del Módulo 3: ASP.NET y C#*