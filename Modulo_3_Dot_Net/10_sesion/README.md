# Sesión 10: ASP.NET y C#

## Fecha: 23/05/2025

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

### Ejercicio 10: Implementación de UsuarioService.

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
    }
}
```

Program.cs
```c# 
using PrimeraAPI.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<UsuarioService>();

//middleware

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
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