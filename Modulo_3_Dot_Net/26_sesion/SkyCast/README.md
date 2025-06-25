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

#### :
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
namespace SkyCast.Services;

public record WeatherDto(string Name, MainData main, IEnumerable<WeatherInfo> Weather);
public record MainData(double Temp, double Humidity);
public record WeatherInfo(string Description, string Icon);
```

WeatherService.cs
```cs
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace SkyCast.Services;

public class WeatherService
{
    private readonly HttpClient _http;
    private readonly string _key;
    private const string baseURL = "https://openweathermap.org/data/2.5/";
    public WeatherService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _key = config["OpenWeather.key"] ?? "";
    }

    public async Task<WeatherDto?> GetByCityAsync(string city)
    {
        var url = $"{baseURL}/weather?q={Uri.EscapeDataString(city)}&units=metric&appid={_key}&lang=es";

        return await _http.GetFromJsonAsync<WeatherDto>(url);
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