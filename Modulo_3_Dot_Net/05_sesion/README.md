# Sesión 05: ASP.NET y C#

## Fecha: 16/05/2025

## Objetivos de la Sesión

- Introducción a ASP.NET y C#

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Introducción a .NET 8 y Visual Studio Code
   - Fundamentos de sintaxis y tipos de datos
   - Operadores y entradas/salidas básicas
   - Estructuras de control - Condicionales
   - Estructuras de control - Bucles

## Ejercicios Realizados

### Ejercicio 05: Método - Create, Read, Update, Delete.

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
```

```c#
// ProductoService.cs
using Microsoft.Data.SqlClient;
using PrimeraAPI.Models;
using Microsoft.Extensions.Configuration;

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
/*
        // Obtener un producto por ID
        public async Task<Producto> GetByIdAsync()
        {

        }

        // Crear un nuevo producto
        public async Task<Producto> CreateAsync(Producto producto)
        {

        }
*/
    }
}
```

```json
// appsettings.json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "TiendaDB": "Server=DESKTOP-F7M6I8G\\SQLEXPRESS;Database=TiendaDB;Trusted_Connection=True;Encrypt=False;"
  },
  "AllowedHosts": "*"
}
```

## Desafíos Encontrados

- **Impedimentos:** Para esta actividad tuve un problema para conectar la base de datos, ya que al usar Microsoft.Data.SqlClient, por defecto intenta encriptar la conexión con TLS/SSL, por lo que solo tuve que evitar la encriptación, ya que por el momento el proyecto solo funcionará de manera Local. 

## Recursos Adicionales

- .NET 8: Arquitectura, Seguridad, Monitoreo y Doc. de APIs
- C# TOTAL . Programador Experto en 28 días
- Master en ASP.NET MVC - Entity Framework (.NET 9)
- Curso de C#
- Aprende a programar desde cero con C#, Microsoft .NET y WPF
- Domina la programación C# con Visual Studio Code DESDE CERO
- Programación en C de Cero a Experto con Estructuras de Datos
- Master en C# de Cero (Windows Form - Xamarin -APP Consola)

## Próximos Pasos

- Continuar los avances en cursos de Udemy. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre C#.

---

*Entregable correspondiente a la Semana 9 del Módulo 3: ASP.NET y C#*