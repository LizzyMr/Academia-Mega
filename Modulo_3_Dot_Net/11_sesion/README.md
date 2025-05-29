# Sesión 11: ASP.NET y C#

## Fecha: 26/05/2025

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

### Ejercicio 11: Middleware y Uso de Tokens.

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

ProductosController.cs
```cs
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpPost] // POST /api/productos
        public async Task<IActionResult> Create(Producto nuevo)
        {
            var created = await _service.CreateAsync(nuevo);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /*
                - READ -
        */
        [Authorize]
        [HttpGet] //GET /api/productos
        public async Task<IActionResult> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        [Authorize]
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
        [Authorize]
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
        [Authorize]
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

UsuarioService.cs
```c# 
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using PrimeraAPI.Models;
using Microsoft.Extensions.Configuration;

namespace PrimeraAPI.Data
{
    public class UsuarioService
    {
        private readonly string _connectionString;
        public UsuarioService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("TiendaDB")!;
        }

        // Funcion para hashear la contraseña
        private string Hash(string pass)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(pass));
            return Convert.ToBase64String(bytes);
        }

        public async Task<bool> RegistroAsync(string username, string password)
        {
            var hash = Hash(password);
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var cmd = new SqlCommand(
                "INSERT INTO Usuarios (NombreUsuario, PasswordHash) VALUES (@user, @pass)",
                connection
            );
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", hash);

            try
            {
                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                return false;
            }
        }

        public async Task<bool> ValidateCredentialAsync(string username, string pass)
        {
            var hash = Hash(pass);
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var cmd = new SqlCommand(
                "SELECT COUNT(1) FROM Usuarios WHERE NombreUsuario=@u AND PasswordHash=@h",
                connection
            );
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@h", hash);
            var count = (int)await cmd.ExecuteScalarAsync()!;
            return count == 1;

        }
    }
}
```

Program.cs
```c# 
using PrimeraAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<UsuarioService>();


//middleware
var keyString = builder.Configuration["JwtKey"];
if (string.IsNullOrWhiteSpace(keyString))
    throw new InvalidOperationException("Falta configurar el jwtKey en appsettings");


var key = Encoding.ASCII.GetBytes(keyString);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
```

appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "JwtKey": "60bac12ba97e51b50426bf58c54f699bf33d7852975825eb91fb0bf3c38880b9",
  "ConnectionStrings": {
    "TiendaDB": "Server=DESKTOP-F7M6I8G\\SQLEXPRESS;Database=TiendaDB;Trusted_Connection=True;Encrypt=False;"
  },
  "AllowedHosts": "*"
}
```

.gitignore
```git
bin/
obj/
appsettings.json
```

#### TiendaMVC:
Program.cs
```cs
using TiendaMVC.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IProductoApiService, ProductoApiService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5205");
});

builder.Services.AddScoped<HttpContextAccesor>();
builder.Services.AddSession();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

ApiClient.cs
```cs
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
            if (!string.IsNullOrEmpty(token));
        }
    }
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