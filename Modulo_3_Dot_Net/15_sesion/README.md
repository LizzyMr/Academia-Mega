# Sesión 15: ASP.NET y C#

## Fecha: 30/05/2025

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

### Ejercicio 15: Proyecto - TaskManager: Implementar los Métodos faltantes.

Program.cs
```c#
using Microsoft.AspNetCore.Mvc;
using TaskManager.Repositories;
using TaskManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllers();
builder.Services.AddScoped<INotificationService, EmailNotificationService>();
builder.Services.AddScoped<INotificationService, SmsNotificationService>();
builder.Services.AddScoped<ITaskRepository, InMemoryTaskRepository>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
```

BaseClass.cs
```cs
namespace TaskManager.Models
{
    public abstract class BaseClass
    {
        public Guid id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
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
        Task<TaskItem?> GetAsync(Guid id);
        Task AddAsync(TaskItem taskItem);
        Task UpdateAsync(TaskItem taskItem);
        Task DeleteAsync(Guid id);
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
    {

        private readonly ConcurrentDictionary<Guid, TaskItem> _db = new();

        public Task<IEnumerable<TaskItem>> GetAllAsync() =>
        Task.FromResult(_db.Values.AsEnumerable());
        public Task<TaskItem?> GetAsync(Guid id) =>
        Task.FromResult(_db.GetValueOrDefault(id));

        public Task AddAsync(TaskItem task)
        {
            _db[task.id] = task;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TaskItem task)
        {
            _db[task.id] = task;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _db.TryRemove(id, out _);
            return Task.CompletedTask;
        }
    }
}
```

INotificationService.cs
```c# 
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface INotificationService
    {
        Task NotifyTaskCreatedAsync(TaskItem taskItem);
    }
}
```

NotificationService.cs
```c# 
using TaskManager.Models;

namespace TaskManager.Services
{
    public abstract class NotificationService : INotificationService
    {
        protected string SenderName { get; }
        protected NotificationService(string senderName) =>
            SenderName = senderName;

        public abstract Task NotifyTaskCreatedAsync(TaskItem task);
    }
}
```

EmailNotificationService.cs
```c# 
using System.Diagnostics;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class EmailNotificationService : NotificationService
    {
        public EmailNotificationService() : base("Gestor de tareas")
        { }

        public override Task NotifyTaskCreatedAsync(TaskItem task)
        {
            // Imaginate que aqui se manda el correo
            Console.WriteLine($"[EMAIL] {SenderName}: Nueva tarea '{task.Title}'");
            return Task.CompletedTask;
        }
    }
}
```

SmsNotificationService.cs
```c# 
using TaskManager.Models;

namespace TaskManager.Services
{ 
    public class SmsNotificationService : NotificationService
    {
        public SmsNotificationService() : base("Gestor de tareas")
        { }

        public override Task NotifyTaskCreatedAsync(TaskItem task)
        {
            // Imaginate que aqui se manda el SMS
            Console.WriteLine($"[SMS] {SenderName}: Nueva tarea '{task.Title}'");
            return Task.CompletedTask;
        }
    }
}
```

TasksController.cs
```c# 
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Repositories;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repo;
        private readonly IEnumerable<INotificationService> _notifiers;

        public TasksController(ITaskRepository repo, IEnumerable<INotificationService> notifiers)
        {
            _repo = repo;
            _notifiers = notifiers;
        }

        // GET /api/tasks
        [HttpGet]  
        public async Task<IEnumerable<TaskItem>> GetAll() =>
            await _repo.GetAllAsync(); 

        // GET /api/tasks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetById(Guid id)
        {
            var task = await _repo.GetAsync(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // POST /api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskItem>> Create(TaskItem newTask)
        {
            await _repo.AddAsync(newTask);

            // Notificar a todos los servicios (email y sms)
            foreach (var notifier in _notifiers)
            {
                await notifier.NotifyTaskCreatedAsync(newTask);
            }

            return CreatedAtAction(nameof(GetById), new { id = newTask.id }, newTask);
        }

        // PUT /api/tasks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TaskItem updatedTask)
        {
            var existing = await _repo.GetAsync(id);
            if (existing == null)
                return NotFound();

            // Actualizamos los campos necesarios
            existing.Title = updatedTask.Title;
            existing.Description = updatedTask.Description;

            if (updatedTask.IsDone)
                existing.Complete();

            await _repo.UpdateAsync(existing);

            return NoContent();
        }

        // DELETE /api/tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _repo.GetAsync(id);
            if (existing == null)
                return NotFound();

            await _repo.DeleteAsync(id);
            return NoContent();
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