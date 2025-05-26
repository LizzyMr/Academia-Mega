# Sesión 08: ASP.NET y C#

## Fecha: 21/05/2025

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

### Ejercicio 08: Implementar consumo de API.

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

        //GET Productos/Create
        public IActionResult Create() -> View();

        //POST /Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {}

        public IActionResult Details(int id)
        {
            return View(new Producto());
        }
    }
}
```

Dentro del siguiente archivo se agregó este fragmento de código, para especificar la Base de Datos:
Program.cs
```c#
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IProductoApiService, ProductoApiService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5205");
});
```

IProductoApiService.cs
```c# 
using TiendaMVC.Models;

namespace TiendaMVC.Services
{
    public interface IProductoApiService
    {
        Task<List<Producto>> GetAllAsync();
       // Task<Producto?> GetByIdAsync(int id);
        Task<Producto?> CreateAsync(Producto p);
       // Task<bool> UpdateAsync(int id, Producto p);
       // Task<bool> DeleteAsync(int id);

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

        public async Task<Producto?> CreateAsync(Producto p)
        {
            var response = await _http.PostAsJsonAsync("api/productos", p);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<Producto>();
        }    
    }
}
```

Create.cshtml
```c# html
@model TiendaMVC.Models.Producto
@{
    ViewData["Title"] = "Crear producto";
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