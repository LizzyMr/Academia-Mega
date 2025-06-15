# Sesión 19: ASP.NET y C#

## Fecha: 05/06/2025

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

### Ejercicio 19: TaskManagerObserver

#### TaskManagerObserver
Program.cs
```c#
using Domain;
using Infraestructure;
using Subscribers;

var bus = new EventBus();
var repo = new TaskRepository(bus);

bus.Subscribe(new EmailNotifier());
bus.Subscribe(new SmsNotifier());
bus.Subscribe(new ConsoleUI());

// LA PRUEBA

var task1 = repo.Add(new TaskItem { Title = "Aprender Patrón Observer" });
var task2 = repo.Add(new TaskItem { Title = "Conectar PubSub a todo el Proyecto" });

task1.Complete();
repo.Update(task1);
Console.WriteLine(task1.IsDone);

repo.Delete(task2.id);
```

TaskItem.cs
```cs
namespace Domain;

public class TaskItem
{
    public Guid id { get; } = Guid.NewGuid();
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public bool IsDone { get; private set; }

    public void Complete() => IsDone = true;
}
```

TaskEvent.cs
```cs
namespace Domain.Events;

public record TaskEvent(string EventName, TaskItem Payload);
```

EventBus.cs
```cs
using Domain.Events;

namespace Infraestructure;

public class EventBus : IObservable<TaskEvent>
{
    private readonly List<IObserver<TaskEvent>> _observers = [];

    public IDisposable Subscribe(IObserver<TaskEvent> observer)

    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);

        return new Unsuscriber(_observers, observer);
    }

    public void Publish(TaskEvent ev)
    {
        foreach (var obs in _observers.ToArray())
            obs.OnNext(ev);
    }

    private sealed class Unsuscriber(List<IObserver<TaskEvent>> list, IObserver<TaskEvent> obs) : IDisposable
    {
        public void Dispose() => list.Remove(obs);
    }
}
```

TaskRepository.cs
```c# 
using Domain;
using Domain.Events;

public class TaskRepository
{
    private readonly List<TaskItem> _store = [];
    private readonly EventBus _bus;

    public TaskRepository(EventBus bus) => _bus = bus;
    public IEnumerable<TaskItem> GetAll() => _store.AsReadOnly();

    public TaskItem Add(TaskItem task)
    {
        _store.Add(task);
        _bus.Publish(new TaskEvent("Created", task));
        return task;
    }

    public void Update(TaskItem task)
    {
        var idx = _store.FindIndex(t => t.id == task.id);
        if (idx >= 0)
            _store[idx] = task;

        _bus.Publish(new TaskEvent("Updated", task));
    }

    public void Delete(Guid id)
    {
        var task = _store.FirstOrDefault(t => t.id == id);
        if (task is null)
            return;
        _store.Remove(task);

        _bus.Publish(new TaskEvent("Deleted", task));
    } 
}
```

EmailNotifier.cs
```c# 
using Domain.Events;
using System.Diagnostics;

namespace Subscribers;

public class EmailNotifier : IObserver<TaskEvent>
{
    public void OnCompleted() { }
    public void OnError(Exception error) { }

    public void OnNext(TaskEvent taskEvent)
    {
        if (taskEvent.EventName == "Created")
            Console.WriteLine($"[EMAIL] Nueva tarea: {taskEvent.Payload.Title}");
    }
}
```

SmsNotifier.cs
```cs
using Domain.Events;
using System.Diagnostics;

namespace Subscribers;

public class SmsNotifier : IObserver<TaskEvent>
{
    public void OnCompleted() { }
    public void OnError(Exception error) { }

    public void OnNext(TaskEvent taskEvent)
    {
        if (taskEvent.EventName == "Deleted")
            Console.WriteLine($"[SMS] Tarea eliminada: {taskEvent.Payload.Title}");
    }
}
```

ConsoleUI.cs
```cs
using Domain.Events;
using System.Diagnostics;

namespace Subscribers;

public class ConsoleUI : IObserver<TaskEvent>
{
    public void OnCompleted() { }
    public void OnError(Exception error) =>
        Console.WriteLine($"Error: {error.Message}");

    public void OnNext(TaskEvent taskEvent) =>
        Console.WriteLine($"UI -> {taskEvent.EventName} : {taskEvent.Payload.Title}");
}
```

#### TaskManager.Shared
TaskItem.cs
```cs
namespace TaskManager.Shared.Domain;

public class TaskItem
{
    public Guid id { get; } = Guid.NewGuid();
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public bool IsDone { get; private set; }

    public void Complete() => IsDone = true;
}
```

TaskEvent.cs
```cs
using TaskManager.Shared.Domain;

namespace TaskManager.Shared.Events; // ✅ Correcto

public record TaskEvent(string EventName, TaskItem Payload);
```

EventBus.cs
```cs
using TaskManager.Shared.Events;

namespace TaskManager.Shared.PubSub;

public class EventBus : IObservable<TaskEvent>
{
    private readonly List<IObserver<TaskEvent>> _observers = [];

    public IDisposable Subscribe(IObserver<TaskEvent> observer)

    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);

        return new Unsuscriber(_observers, observer);
    }

    public void Publish(TaskEvent ev)
    {
        foreach (var obs in _observers.ToArray())
            obs.OnNext(ev);
    }

    private sealed class Unsuscriber(List<IObserver<TaskEvent>> list, IObserver<TaskEvent> obs) : IDisposable
    {
        public void Dispose() => list.Remove(obs);
    }
}
```

#### TaskManager
Se agrego la referencia de TaskManager.Shared al TaskManager.
```cs
  <ItemGroup>
    <ProjectReference Include="..\TaskManager.Shared\TaskManager.Shared.csproj" />
  </ItemGroup>
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

Comenzamos con el TaskManagerObserver.

---

*Entregable correspondiente a la Semana 11 del Módulo 3: ASP.NET y C#*