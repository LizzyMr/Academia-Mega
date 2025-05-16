# Sesión 03: ASP.NET y C#

## Fecha: 14/05/2025

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

### Ejercicio 03: Actividad Saludo

```c#
// program.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SaludoController : ControllerBase
{

    //GET /saludo
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { mensaje = "Hola desde el SaludoController" });
    }

    // GET /saludo/personalizado/{name}
    [HttpGet("personalizado/{nombre}")]
    public IActionResult GetPersonalizado(string nombre)
    {
        var respuesta = new
        {
            mensaje = $"Holaa, {nombre}"
        };

        return Ok(respuesta);
    }

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