# Sesión 18: ASP.NET y C#

## Fecha: 04/06/2025

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

### Ejercicio 18: TaskManagerObserver

Program.cs
```c#
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
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
    private readonly List<IObservable<TaskEvent>> _observers = [];

    public IDisposable Suscribe(IObserver<TaskEvent> observer)
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
//  PENDIENTE PARA LA SIGUIENTE SESION
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