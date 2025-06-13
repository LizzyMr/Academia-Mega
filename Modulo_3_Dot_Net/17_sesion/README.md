# Sesión 17: ASP.NET y C#

## Fecha: 03/06/2025

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

### Ejercicio 17: TaskForm

Program.cs - TaskManagerClient
```c#
using TaskManagerClient.Services;
using TaskManagerClient;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var AllowedOrigin = "BlazorClient";
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowedOrigin, policy =>
    {
        policy.WithOrigins("http://localhost:5030")
            .AllowAnyHeader()
            .AllowAnyMethod();
            // .AllowCredentiads() // Solo si usamos una cookie de sesión
    });
});

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

Program.cs - TaskManager
```cs
using Microsoft.AspNetCore.Mvc;
using TaskManager.Repositories;
using TaskManager.Services;

var builder = WebApplication.CreateBuilder(args);

var AllowedOrigin = "BlazorClient";
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowedOrigin, policy =>
    {
        policy.WithOrigins("http://localhost:5030")
            .AllowAnyHeader()
            .AllowAnyMethod();
            // .AllowCredentiads() // Solo si usamos una cookie de sesión
    });
});

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

app.UseCors(AllowedOrigin);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
```

Home.razor
```cs
@page "/"
@using TaskManagerClient.Services;
@using TaskManagerClient.Models;

@inject ITaskReader TaskReader 
@inject ITaskWriter TaskWriter 

<h2>Tareas</h2>

@if (tasks is null)
{
    <p><em>Cargando...</em></p>
}
else
{
    <ul class="list-group">
        @foreach (var t in tasks)
        {
            <li class="list-group-item d-flex justify-content-between">
                <span>
                    <input type="checkbox" @bind="t.IsDone" />
                    @t.Title
                </span>
                <button class="btn btn-danger btn-sm"
                        @onclick="@(()=>Delete(t.id))">Elimina</button>
            </li>
        }
    </ul>
    <TaskForm OnSaved="Refresh"/>
}

@code
{
    List<TaskItem>? tasks;

    protected override async Task OnInitializedAsync() => await Refresh();

    async Task Refresh()
    {
        tasks = (await TaskReader.GetAllAsync()).ToList();
    }

    async Task Delete(Guid id)
    {
        await TaskWriter.DeleteAsync(id);
        await Refresh();
    }
}
```

TaskForm.razor
```cs
@using TaskManagerClient.Services;
@using TaskManagerClient.Models;

@inject ITaskWriter TaskWriter 

<EditForm Model="task" OnValidSubmit="Save">
    <InputText @bind-Value="task.Title" class="form-control" placeholder="Titulo"/>
    <InputTextArea @bind-Value="task.Description" class="form-control my-2" placeholder="Descripción"/>
    <button class="btn btn-primary">Guardar</button>
</EditForm>

@code
{
    private TaskItem task = new();

    [Parameter] public EventCallback OnSaved { get; set; }

    async Task Save()
    {
        await TaskWriter.AddAsync(task);
        task = new();
        await OnSaved.InvokeAsync();
    }
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

*Entregable correspondiente a la Semana 11 del Módulo 3: ASP.NET y C#*