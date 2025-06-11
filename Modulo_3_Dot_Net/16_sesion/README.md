# Sesión 16: ASP.NET y C#

## Fecha: 02/06/2025

## Objetivos de la Sesión

- Introducción a ASP.NET y C#

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Patrones de diseño - Introducción
   - Patrón Singleton
   - Patrón Factory - Method
   - Patrón Strategy
   - Patrón Repositorio

## Ejercicios Realizados

### Ejercicio 16: TaskManagerClient: 

Program.cs
```c#
using TaskManagerClient.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostingBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");

builder.Services.AddSingleton(sp =>
{
    var http = new HttpClient();
    return http;
});

builder.Services.AddScoped<ITaskReader, TaskService>();
builder.Services.AddScoped<ITaskWriter, TaskService>();


await builder.Build().RunAsync();
```

TaskItem.cs
```cs
// Este nos va servir para el DTO del backend

namespace TaskManagerClient.Models;

public class TaskItem
{
    public Guid id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsDone { get; set; }
}
```

ApiEndpoints.cs
```cs
namespace TaskManagerClient.Helpers;

public static class ApiEndpoints
{
    public const string Base = "http://localhost:5244/api";
    public const string Tasks = $"{Base}/Tasks";
}
```

ITaskReader.cs
```cs
using TaskManagerClient.Models;

namespace TaskManagerClient.Services;

public interface ITaskReader
{
    Task<IEnumerable<TaskItem>> GetAllAsync();
}
```

ITaskWriter.cs
```c# 
using TaskManagerClient.Models;

namespace TaskManagerClient.Services;

public interface ITaskWriter
{
    Task<TaskItem> AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem);
    Task DeleteAsync(Guid id);

}
```

ITaskService.cs
```c# 
using System.Net.Http.Json;
using TaskManagerClient.Helpers;
using TaskManagerClient.Models;

namespace TaskManagerClient.Services;

public class TaskService(HttpClient http) : ITaskReader, ITaskWriter
{
    public async Task<IEnumerable<TaskItem>> GetAllAsync() =>
        await http.GetFromJsonAsync<IEnumerable<TaskItem>>(ApiEndpoints)
            ?? Enumerable.Empty<TaskItem>();

    public async Task<TaskItem> AddAsync(TaskItem, task)
    {
        var response = await http.PostAtJsonAsync(ApiEndpoints.Tasks, task);
        return await response.Content - ReadFromJsonAsync<TaskItem>() ??
            throw new InvalidOperationException("Respuesta vacía");
    }

    public Task UpdateAsync(TaskItem task) =>
        http.PutAsJsonAsync($"ApiEndpoints.Tasks/{task.id}");

    public Task DeleteAsync(Guid id) =>
        http.DeleteAsync($"ApiEndpoints.Tasks/{id}");
}
```



## Desafíos Encontrados

- **Sin Impedimentos:** Para esta actividad no tuve ningún problema. 

## Recursos Adicionales

- Patrones de diseño en C# Aplicados en ASP .Net
- Patrones de diseño de software y principios SOLID
- Curso completo de programación C# en .Net y muchísimo más

## Próximos Pasos

- Continuar los avances en cursos de Udemy. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre C#.

---

*Entregable correspondiente a la Semana 10 del Módulo 3: ASP.NET y C#*