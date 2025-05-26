# Sesión 07: ASP.NET y C#

## Fecha: 20/05/2025

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

### Ejercicio 07: Crear página web: TiendaMVC.

```c#
// Producto.cs
namespace TiendaMVC.Models
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
// ProductoController.cs
using Microsoft.AspNetCore.Mvc;
using TiendaMVC.Models;
using System.Collections.Generic;

namespace TiendaMVC.Controllers
{
    public class ProductosController : Controller
    {
        private static readonly List<Producto> _productos = new()
        {
            new Producto { Id = 1, Nombre = "Xiaomi 15 Ultra", Precio = 33000.00m},
            new Producto { Id = 2, Nombre = "HONOR Magic 7 Pro", Precio = 29000.00m},
        };

        public IActionResult Index()
        {
            return View(_productos);
        }

        public IActionResult Details(int id)
        {
            var product = _productos.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return View(product);
        }
    }
}
```
Dentro del [div class="container-fluid"] agregamos la sección Productos:
```c# html
// _Layout.cshtml
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="" asp-controller="Productos" asp-action="Index">Productos</a>
    </li>
```

```c# html
// index.cshtml
@model IEnumerable<Producto>
@{
    ViewData["Title"] = "Listado de productos";
}

<table>
    <thead>
        <tr>
            <th>Id</th>
            <th>Nombre</th>
            <th>Precio</th>
            <th>Acciones</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var item in Model)
        {
            <tr>
                <td>@item.Id</td>
                <td>@item.Nombre</td>
                <td>@item.Precio.ToString("C")</td>
                <td>
                    <a asp-action="Details" asp-route-id="@item.Id">Ver Detalle</a>
                </td>
            </tr>
        }
    </tbody>
</table>
```

```c# html
// Details.cshtml
@model Producto
@{
    ViewData["Title"] = "Detalle del producto";
}

<h1>@ViewData["Title"]</h1>

<div>
    <h2>@Model.Nombre</h2>
    <dl>
        <dt> Id </dt>
        <dd>@Model.Id</dd>

        <dt> Precio </dt>
        <dd>@Model.Precio.ToString("C")</dd>
    </dl>
</div>

<a asp-action="Index"> Volver al listado</a>
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