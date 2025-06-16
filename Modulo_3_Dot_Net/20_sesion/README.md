# Sesión 20: ASP.NET y C#

## Fecha: 06/06/2025

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

### Ejercicio 20: Correcta conexión con el Task Manager Observer.

#### TaskManager


Program.cs: Agregamos las siguientes líneas dentro del archivo (en sus respectivos lugares).
```cs 
using TaskManager.Shared.PubSub;

builder.Services.AddSingleton<EventBus>();
builder.Services.AddSignalR();

// Despues de Map.Controllers();
app.MapHub<TaskEventHub>("/taskEvents");
```

TaskEventHub.cs
```c#
using Microsoft.AspNetCore.SignalR;
using TaskManager.Shared.Events;

namespace TaskManager.Hubs
{
    public class TaskEventHub : Hub {  }
}
```

InMemoryTaskrepository.cs: Agregamos tambien las siguientes líneas de código.
```cs
using TaskManager.Shared.PubSub;
using TaskManager.Shared.Events;
using TaskManager.Shared.Domain;
using Microsoft.AspNetCore.SignalR;

private readonly EventBus _bus;
private readonly IHubContext<TaskEventHub> _hub;

public InMemoryTaskRepository(EventBus bus, IHubContext<TaskEventHub> hub)
{
    _bus = bus;
    _hub = hub;
}

public Task AddAsync(TaskItem task)
{
    _db[task.id] = task;
    var ev = new TaskEvent("Created", task);
    _bus.Publish(ev);
    return _hub.Clients.All.SendAsync("TaskEvent", ev);
}

public Task UpdateAsync(TaskItem task)
{
    _db[task.id] = task;
    var ev = new TaskEvent("Updated", task);
    _bus.Publish(ev);
    return _hub.Clients.All.SendAsync("TaskEvent", ev);
}

public Task DeleteAsync(Guid id)
{
    if (_db.TryRemove(id, out var removed))
    {
        var ev = new TaskEvent("Deleted", removed);
        _bus.Publish(ev);
        return _hub.Clients.All.SendAsync("TaskEvent", ev);
    }
    return Task.CompletedTask;
}
```


#### TaskManagerObserver
TaskManagerObserver.csproj: Agregamos tambien la referencia y el paquete de SignalR.
```cs
  <ItemGroup>
    <ProjectReference Include="..\TaskManager.Shared\TaskManager.Shared.csproj" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.SignalR" Version="1.2.0" />
  </ItemGroup>
```

#### TaskManager.Shared
Se realizaron diversos ajustes, principalmente en los using y namespace, para conectarlos al Shared correctamente...

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

Una vez que tenemos la referencia agregada del TaskManager.Shared al TaskManager, podemos continuar los avances del proyecto.

---

*Entregable correspondiente a la Semana 11 del Módulo 3: ASP.NET y C#*