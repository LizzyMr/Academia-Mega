# Sesión 25: ASP.NET y C#

## Fecha: 16/06/2025

## Objetivos de la Sesión

- Introducción a ASP.NET y C#

## Temas Cubiertos

1. **Fundamentos de C#**
   - Implementando el Patrón Repositorio con EF Core
   - Aplicaciones de consola más complejas
   - Introducción a aplicaciones de escritorio
   - Buenas prácticas y principios SOLID
   - Pruebas unitarias con xUnit

## Ejercicios Realizados

### Ejercicio 25: SkyCast

input.css
```css
@tailwind base;
@tailwind components;
@tailwind utilites;
```

SkyCast.csproj
```c#
  <Target Name="Tailwind" BeforeTargets="Build">
    <Exec Command="dotnet tailwindcss -i Styles/input.css -o wwwroot/css/app.css --minify"/>
  </Target>
```

tailwind.config.js
```json
/** @type {import { 'tailwindcss' }.Config* } */

module.exports = {
    content: [
        "./**/*.razor",
        "./wwwroot/index.html"
    ],
    theme:{
        extends: {}
    },
    plugins: []
}
```

index.html
```html
<link href="css/app.css" rel="stylesheet" />
```

Models.cs
```cs
namespace SkyCast.Services
{
    /// <summary>
    /// Representa los datos meteorológicos principales para una ubicación.
    /// </summary>
    /// <param name="Name">Nombre de la ciudad o ubicación.</param>
    /// <param name="main">Datos principales del clima (temperatura, humedad, etc.).</param>
    /// <param name="Weather">Lista de condiciones climáticas (descripción, icono, etc.).</param>
    public record WeatherDto(string Name, MainData main, IEnumerable<WeatherInfo> Weather);

    /// <summary>
    /// Contiene información principal del clima, como la temperatura y la humedad.
    /// </summary>
    /// <param name="Temp">Temperatura actual en grados Celsius.</param>
    /// <param name="Humidity">Porcentaje de humedad relativa.</param>
    public record MainData(double Temp, double Humidity);

    /// <summary>
    /// Representa información específica sobre una condición climática.
    /// </summary>
    /// <param name="Description">Descripción textual del clima (e.g. "cielo claro").</param>
    /// <param name="Icon">Código del icono correspondiente a la condición climática.</param>
    public record WeatherInfo(string Description, string Icon);
}

```

WeatherService.cs
```cs
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace SkyCast.Services
{
    /// <summary>
    /// Servicio para obtener datos meteorológicos desde la API de OpenWeather.
    /// </summary>
    public class WeatherService
    {
        private readonly HttpClient _http;
        private readonly string _key;
        private const string baseURL = "https://openweathermap.org/data/2.5/";

        /// <summary>
        /// Inicializa una nueva instancia del <see cref="WeatherService"/>.
        /// </summary>
        /// <param name="http">Instancia de <see cref="HttpClient"/> utilizada para realizar las solicitudes HTTP.</param>
        /// <param name="config">Configuración de la aplicación que contiene la clave de API de OpenWeather.</param>
        public WeatherService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _key = config["OpenWeather.key"] ?? "";
        }

        /// <summary>
        /// Obtiene los datos del clima para una ciudad específica.
        /// </summary>
        /// <param name="city">Nombre de la ciudad.</param>
        /// <returns>Un objeto <see cref="WeatherDto"/> con los datos del clima, o <c>null</c> si no se encuentra la ciudad.</returns>
        public async Task<WeatherDto?> GetByCityAsync(string city)
        {
            var url = $"{baseURL}/weather?q={Uri.EscapeDataString(city)}&units=metric&appid={_key}&lang=es";

            return await _http.GetFromJsonAsync<WeatherDto>(url);
        }
    }
}
```

## Desafíos Encontrados

- **Sin Impedimentos:** Para esta actividad no tuve ningún problema.


## Recursos Adicionales

- Curso Completo de Programación C# en .Net y muchísimo más
- Programación C# con Visual Studio Code 2021 de 0 a EXPERTO
- Aprende a programar desde cero con C#, Microsoft .NET y WPF
- Clean Architecture en C# .NET, un curso basado en conceptos
- Pruebas unitarias con xUnit en .NET

## Próximos Pasos

- Continuar los avances en cursos de Udemy. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Fue una práctica muy interesante y entretenida.

---

*Entregable correspondiente a la Semana 13 del Módulo 3: ASP.NET y C#*