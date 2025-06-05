# Sesión 14: ASP.NET y C#

## Fecha: 29/05/2025

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

### Ejercicio 14: Proyecto - TaskManager.

Program.cs
```c#
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
```

BaseClass.cs
```cs
namespace TaskManager.Models
{
    public abstract class BaseClass
    {
        public Guid id { get; private set: } = Guid.NewGuid();
        public DateTime CreatedAt { get;  private set: } = DateTime.UtcNow;
    }
}
```

TaskItem.cs
```cs
namespace TaskManager.Models
{
    public class TaskItem : BaseClass
    {

        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; private set; }

        public void Complete() => IsDone = true;
    }
}
```

ITaskRepository.cs
```cs
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task AddAsync(TaskItem taskItem);
    }
}
```

InMemoryTaskRepository.cs
```c# 
using TaskManager.Models;
using System.Collections.Concurrent;

namespace TaskManager.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {}
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