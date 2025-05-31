# Sesión 12: ASP.NET y C#

## Fecha: 27/05/2025

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

### Ejercicio 12: .

#### PrimeraAPI:
AuthController.cs
```c#
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using PrimeraAPI.Data;
using System.IdentityModel.Tokens.Jwt;

namespace PrimeraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly IConfiguration _config;
        public AuthController(UsuarioService usuarioService, IConfiguration config)
        {
            _usuarioService = usuarioService;
            _config = config;
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Register(UserLogin user)
        {
            var ok = await _usuarioService.RegistroAsync(user.Username, user.Password);
            if (!ok) return Conflict(new { message = "El usuario ya existe" });
            var token = GenerateToken(user.Username);
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin user)
        {
            var valid = await _usuarioService.ValidateCredentialAsync(user.Username, user.Password);
            if (!valid) return Unauthorized(new { message = "Acceso no autorizaodo! Credenciales invalidas." });
            var token = GenerateToken(user.Username);
            return Ok(new { token });
        }

        private string GenerateToken(string username)
        {
            var key = Encoding.ASCII.GetBytes(_config["JwtKey"]!);
            var claims = new[] {
                new Claim(ClaimTypes.Name, username)
            };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }

    public class UserLogin
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
```

#### TiendaMVC:
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
    }
}
```

ProductoApiService.cs
```cs
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TiendaMVC.Models;

namespace TiendaMVC.Services
{
    public class ProductoApiService : IProductoApiService
    {

        private readonly HttpClient _http;
        private readonly IHttpContextAccessor _context;
        public ProductoApiService(HttpClient http, IHttpContextAccessor context)
        {
            _http = http;
            _context = context;

            var token = _context.HttpContext!.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

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

        // Autenticación
        public async Task<bool> LoginAsync(User user)
        {
            var response = await _http.PostAsJsonAsync("/api/auth/login", user);
            if (!response.IsSuccessStatusCode) return false;
            var obj = await response.Content.ReadFromJsonAsync<TokenResponse>();
            _context.HttpContext!.Session.SetString("JWToken", obj!.Token);
            return true;
        }
    }

    public class TokenResponse { public string Token { get; set; } = ""; }

}
```

User.cs
```c# 
using System.ComponentModel.DataAnnotations;

namespace TiendaMVC.Models
{
    /// <summary>
    /// Modelo de user para los datos de autenticación
    /// </summary>
    public class User
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El username debe tener entre 3 y 50 caracteres.")]
        [Display(Name = "Usuario")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 50 caracteres.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; } = string.Empty;
    }
}
```

Login.cshtml
```c# 
@using TiendaMVC.Models
@model User

@{
    ViewData["Title"] = "Inicio de sesión";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<link rel="stylesheet" href="~/css/login.css" />

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

        <p class="register-link">¿No tienes una cuenta? <a href="#">Regístrate aquí</a></p>
    </div>
</div>

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