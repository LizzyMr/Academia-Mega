# Sesión 04: ASP.NET y C#

## Fecha: 15/05/2025

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

### Ejercicio 04: Método - Create, Read, Update, Delete.

```c#
// program.cs
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
```

## Desafíos Encontrados

- **Sin Impedimentos:** Para esta actividad no tuve ningún problema para realizarla satisfactoriamente. 

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