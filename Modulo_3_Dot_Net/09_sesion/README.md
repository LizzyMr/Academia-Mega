# Sesión 09: ASP.NET y C#

## Fecha: 22/05/2025

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

### Ejercicio 09: Implementación funcionalidad Crear, Editar.
### Tarea 09: Implementar Eliminar y agregar botones.

Producto.cs
```c#
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

ProductoController.cs
```c# 
using Microsoft.AspNetCore.Mvc;
using TiendaMVC.Models;
using TiendaMVC.Services;
using System.Collections.Generic;

namespace TiendaMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoApiService _api;
        public ProductosController(IProductoApiService api) => _api = api;

        //GET /Productos
        public async Task<IActionResult> Index()
        {
            var products = await _api.GetAllAsync();
            return View(products);
        }

        //GET /Productos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _api.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        //GET Productos/Create
        public IActionResult Create() => View();

        //POST /Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (!ModelState.IsValid) return View(producto);

            var created = await _api.CreateAsync(producto);
            if (created == null)
            {
                ModelState.AddModelError("", "Error al crear el producto");
                return View(producto);
            }
            return RedirectToAction(nameof(Index));
        }

        //GET /Productos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _api.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        //POST /Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.Id) return BadRequest();
            if (!ModelState.IsValid) return View(producto);

            var ok = await _api.UpdateAsync(id, producto);
            if (!ok)
            {
                ModelState.AddModelError("", "Error al actualizar el producto");
                return View(producto);
            }
            return RedirectToAction(nameof(Index));
        }

        //GET /Productos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _api.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        //POST /Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _api.DeleteAsync(id);
            if (!deleted)
            {
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
```

IProductoApiService.cs
```c# 
using TiendaMVC.Models;

namespace TiendaMVC.Services
{
    public interface IProductoApiService
    {
        Task<List<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(int id);
        Task<Producto?> CreateAsync(Producto p);
        Task<bool> UpdateAsync(int id, Producto p);
        Task<bool> DeleteAsync(int id);

    }
}
```

ProductoApiService.cs
```c# 
using System.Net.Http.Json;
using TiendaMVC.Models;

namespace TiendaMVC.Services
{
    public class ProductoApiService : IProductoApiService
    {

        private readonly HttpClient _http;
        public ProductoApiService(HttpClient http) => _http = http;

        public async Task<List<Producto>> GetAllAsync() =>
            await _http.GetFromJsonAsync<List<Producto>>("api/productos") ?? new List<Producto>();

        public async Task<Producto?> GetByIdAsync(int id) =>
            await _http.GetFromJsonAsync<Producto>($"api/productos/{id}");

        public async Task<Producto?> CreateAsync(Producto p)
        {
            var response = await _http.PostAsJsonAsync("api/productos", p);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<Producto>();
        }

        public async Task<bool> UpdateAsync(int id, Producto p)
        {
            var response = await _http.PutAsJsonAsync(($"api/productos/{id}"), p);
            return response.IsSuccessStatusCode;
        }   

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync(($"api/productos/{id}"));
            return response.IsSuccessStatusCode;
        } 
    }
}
```

index.cshtml
```c# html
@model IEnumerable<Producto>
@{
    ViewData["Title"] = "Listado de productos";
}
@if (TempData["SuccessMessage"] != null)
{
    <div class="alert alert-success alert-dismissible fade show" role="alert">
        @TempData["SuccessMessage"]
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>
}

<a asp-action="Create" class="btn btn-success mb-3">Agregar Producto</a>
<table class="table table-strped">
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
                    <a asp-action="Details" asp-route-id="@item.Id" class="btn btn-info btn-sm">Ver</a>
                    <a asp-action="Edit" asp-route-id="@item.Id" class="btn btn-warning btn-sm">Editar</a>
                    <a asp-action="Delete" asp-route-id="@item.Id" 
                       class="btn btn-danger btn-sm"
                       onclick="return confirm('¿Estás seguro de que deseas eliminar este producto?');">
                       Eliminar
                    </a>
                </td>
            </tr>
        }
    </tbody>
</table>
```

Create.cshtml
```c# html
@model TiendaMVC.Models.Producto
@{
    ViewData["Title"] = "Crear producto";
}

<h1>@ViewData["Title"]</h1>

<form asp-action="Create" method="post">
    
    <br />
    <div class="form-group">
        <label asp-for="Nombre"></label>
        <input asp-for="Nombre" class="form-control">
        <span asp-validation-for="Nombre" class="text-danger"></span>
    </div>
    <br />
    <div class="form-group">
        <label asp-for="Precio"></label>
        <input asp-for="Precio" class="form-control">
        <span asp-validation-for="Precio" class="text-danger"></span>
    </div>
    <br />
    <button type="submit" class="btn btn-primary">Guardar</button>
    <a asp-action="Index" class="btn btn-secondary">Cancelar</a>

</form>

@section Scripts {
    @{ await Html.RenderPartialAsync("_validationScriptsPartial"); }
}
```
Details.cshtml
```c# html
@model Producto
@{
    ViewData["Title"] = "Detalle del producto";
}

<h1>@ViewData["Title"]</h1>
<br />
<div>
    <h2>@Model.Nombre</h2>
    <dl class="row">
        <dt class="col-sm-2"> Id </dt>
        <dd class="col-sm-10">@Model.Id</dd>

        <dt class="col-sm-2"> Precio </dt>
        <dd class="col-sm-10">@Model.Precio.ToString("C")</dd>
    </dl>
</div>

<div class="mt-3">
    <a asp-action="Edit" asp-route-id="@Model.Id" class="btn btn-warning">Editar</a>
    <a asp-action="Delete" asp-route-id="@Model.Id" class="btn btn-danger">Eliminar</a>
    <a asp-action="Index" class="btn btn-secondary"> Volver al listado</a>
</div>
```

Edit.cshtml
```c# html
@model TiendaMVC.Models.Producto
@{
    ViewData["Title"] = "Editar producto";
}

<h1>@ViewData["Title"]</h1>

<form asp-action="Edit" method="post">
    
    <input type="hidden" asp-for="Id">
    <div class="form-group">
        <label asp-for="Nombre"></label>
        <input asp-for="Nombre" class="form-control">
        <span asp-validation-for="Nombre" class="text-danger"></span>
    </div>
    <br />
    <div class="form-group">
        <label asp-for="Precio"></label>
        <input asp-for="Precio" class="form-control">
        <span asp-validation-for="Precio" class="text-danger"></span>
    </div>
    <br />
    <button type="submit" class="btn btn-primary">Actualizar</button>
    <a asp-action="Index" class="btn btn-secondary">Cancelar</a>

</form>

@section Scripts {
    @{ await Html.RenderPartialAsync("_validationScriptsPartial"); }
}
```

Delete.cs
```c#
@model TiendaMVC.Models.Producto
@{
    ViewData["Title"] = "Eliminar producto";
}

<h1 class="mb-3">@ViewData["Title"]</h1>

<h4>¿Estás seguro que deseas eliminar este producto?</h4>
<hr />
<dl class="row">
    <dt class="col-sm-2">Id</dt>
    <dd class="col-sm-10">@Model.Id</dd>

    <dt class="col-sm-2">Nombre</dt>
    <dd class="col-sm-10">@Model.Nombre</dd>

    <dt class="col-sm-2">Precio</dt>
    <dd class="col-sm-10">@Model.Precio.ToString("C")</dd>
</dl>

<form asp-action="Delete">
    <input type="hidden" asp-for="Id" />
    <button type="submit" class="btn btn-danger">Eliminar</button>
    <a asp-action="Index" class="btn btn-secondary">Cancelar</a>
</form>
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