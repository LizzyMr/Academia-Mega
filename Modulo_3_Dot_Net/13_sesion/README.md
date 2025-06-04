# Sesión 13: ASP.NET y C#

## Fecha: 28/05/2025

## Objetivos de la Sesión

- Introducción a ASP.NET y C#

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Encapsulamiento y propiedades
   - Herencia
   - Polimorfismo y métodos virtuales
   - Clases abstractas e interfaces
   - Delegados y eventos

## Ejercicios Realizados

### Ejercicio 13: .

#### TiendaMVC:
ApiClient.cs
```cs
using System.Net.Http.Headers;
using TiendaMVC.Models;

namespace TiendaMVC.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;
        private readonly IHttpContextAccessor _context;

        public ApiClient(HttpClient http, IHttpContextAccessor context)
        {
            _http = http;
            _context = context;

            // Si es que hay un token de sesion, lo incluimos en cada peticion
            var token = _context.HttpContext!.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public Task<List<Producto>> GetProductosAsync()
            => _http.GetFromJsonAsync<List<Producto>>("api/productos")!;

        // Autenticación
        public async Task<bool> LoginAsync(User user)
        {
            var response = await _http.PostAsJsonAsync("/api/auth/login", user);
            if (!response.IsSuccessStatusCode) return false;
            var obj = await response.Content.ReadFromJsonAsync<TokenResponse>();
            _context.HttpContext!.Session.SetString("JWToken", obj!.Token);
            return true;
        }

        public async Task<bool> RegisterAsync(User user)
        {
            var response = await _http.PostAsJsonAsync("api/auth/registro", user);
            if (!response.IsSuccessStatusCode) return false;
            var obj = await response.Content.ReadFromJsonAsync<TokenResponse>();
            _context.HttpContext!.Session.SetString("JWToken", obj!.Token);
            return true;
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Producto>($"api/productos/{id}");
        }

        public async Task<Producto?> CreateAsync(Producto producto)
        {
            var response = await _http.PostAsJsonAsync("api/productos", producto);
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<Producto>();
        }

        public async Task<bool> UpdateAsync(int id, Producto producto)
        {
            var response = await _http.PutAsJsonAsync($"api/productos/{id}", producto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/productos/{id}");
            return response.IsSuccessStatusCode;
        }

    }

    public class TokenResponse { public string Token { get; set; } = ""; }

}
```

ProductosController.cs
```cs
using Microsoft.AspNetCore.Mvc;
using TiendaMVC.Models;
using TiendaMVC.Services;
using System.Collections.Generic;

namespace TiendaMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApiClient _api;
        public ProductosController(ApiClient api) => _api = api;

        //GET /Productos
        public async Task<IActionResult> Index()
        {
            var products = await _api.GetProductosAsync();
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

Program.cs
```c# 
using TiendaMVC.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

// Habilitamos las sesiones
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpClient<ApiClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5205");
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
```

AccountController.cs
```cs
using Microsoft.AspNetCore.Mvc;
using TiendaMVC.Models;
using TiendaMVC.Services;


namespace TiendaMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiClient _api;
        public AccountController(ApiClient api) => _api = api;

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (!ModelState.IsValid) return View(user);
            var valido = await _api.LoginAsync(user);
            if (!valido)
            {
                ModelState.AddModelError("", "Usuario o contraseña no validos.");
                return View(user);
            }
            return RedirectToAction("Index", "Productos");
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid) return View(user);
            var valido = await _api.RegisterAsync(user);
            if (!valido)
            {
                ModelState.AddModelError("", "Usuario ya registrado.");
                return View(user);
            }
            return RedirectToAction("Index", "Productos");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWToken");
            return RedirectToAction("Login");
        }
    }
}
```

_Layout.cshtml
```c#
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - TiendaMVC</title>
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />
    <link rel="stylesheet" href="~/TiendaMVC.styles.css" asp-append-version="true" />
</head>

@{
    var isLogged = Context.Session.GetString("JWToken") != null;
}

<body>
    <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <div class="container-fluid">
                <a class="navbar-brand" asp-area="" asp-controller="Account" asp-action="Login">TiendaMVC</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
                        </li>
                        @if (isLogged)
                        {
                            <li class="nav-item">
                                <a class="nav-link text-dark" asp-area="" asp-controller="Productos" asp-action="Index">Productos</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link text-dark" asp-area="" asp-controller="Account" asp-action="Logout">Cerrar sesión</a>
                            </li>
                        }
                    </ul>
                </div>
            </div>
        </nav>
    </header>
    <div class="container-body">
        <main role="main" class="pb-3">
            @RenderBody()
        </main>
    </div>

    <footer class="border-top footer text-muted">
        <div class="container">
            &copy; 2025 - TiendaMVC - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
        </div>
    </footer>
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="~/js/site.js" asp-append-version="true"></script>
    @await RenderSectionAsync("Scripts", required: false)
</body>
</html>
```

Login.cshtml
```c# 
@using TiendaMVC.Models
@model User

@{
    ViewData["Title"] = "Inicio de sesión";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

@* <link rel="stylesheet" href="~/css/login.css" /> *@

<div class="login-container">
    <div class="login-box">
        <h2>Iniciar sesión</h2>
        <form asp-action="Login" method="post">
            <div class="form-group">
                <label for="Username">Usuario</label>
                <input asp-for="Username" class="form-control" />
                <span asp-validation-for="Username" class="error-message"></span>
            </div>

            <div class="form-group">
                <label for="Password">Contraseña</label>
                <input asp-for="Password" type="password" class="form-control" />
                <span asp-validation-for="Password" class="error-message"></span>
            </div>

            <button type="submit" class="login-btn">Ingresar</button>
        </form>

        <p class="register-link">¿No tienes una cuenta? <a asp-action="Register">Regístrate aquí</a></p>
    </div>
</div>

@section Scripts {
    @{ await Html.RenderPartialAsync("_ValidationScriptsPartial"); }
}
```

Register.cshtml
```c#
@model User

@{
    ViewData["Title"] = "Registro";
}

<h2>Registro</h2>

<form asp-action="Register" method="post">
    <div>
        <div>
            <label>Usuario</label>
            <input asp-for="Username" />
            <span asp-validation-for="Username"></span>
        </div>
        <div>
            <label>Contraseña</label>
            <input asp-for="Password" type="password" />
            <span asp.validation-for="Password"></span>
        </div>
        <button type="submit">Crear Cuenta</button>
    </div>
</form>

<p class="register-link">¿Ya tienes una cuenta? <a asp-action="Login">Inicia Sesión</a></p>

@section Scripts {
    @{ await Html.RenderPartialAsync("_ValidationScriptsPartial"); }
}
```

## Desafíos Encontrados

- **Sin Impedimentos:** Para esta actividad no tuve ningún problema. 

## Recursos Adicionales

- Programación Orientada a Objetos con C#: Un Caso Práctico
- Curso de programación orientada a objetos con C# y .NET
- C# TOTAL - Programador Experto en 28 días

## Próximos Pasos

- Continuar los avances en cursos de Udemy. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre C#.

---

*Entregable correspondiente a la Semana 10 del Módulo 3: ASP.NET y C#*