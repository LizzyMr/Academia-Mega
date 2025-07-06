# Sesión 03: Kubernetes

## Fecha: 25/06/2025

## Objetivos de la Sesión

- Utilizando las bases aprendidas durante los cursos de Angular y C#, aprenderemos el uso de los contenedores.

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Introducción  a la virtualización de contenedores.
   - Manejo básico de docker.
   - Alternativas a Docker - Podman y Buildah.
   - Instalación de Kubernetes local con Minikube.
   - Otras distribuciones locales - Kind y K3s.

## Ejercicios Realizados

### Ejercicio 03: 

En el siguiente apartado se adjuntaran los archivos modificados para esta actividad. 

appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-F7M6I8G\\SQLEXPRESS;Database=Starbucks;User Id=lizzymr;Password=pass1234*"
  }
}
```

Program.cs
```c#
using Microsoft.EntityFrameworkCore;
using DemoApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnetion");
builder.Services.AddDbContext<MiStarbucksDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
```

Dockerfile
```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY DemoApp/DemoApp.csproj /src/DemoApp

RUN dotnet restore DemoApp/DemoApp.csproj

COPY . .

RUN dotnet publish DemoApp/DemoApp.csproj -c Release -o /app 

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app 

COPY --from=build /app .

EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT [ "dotnet", "DemoApp.dll" ]
```

docker-compose.yml
```yml
version: "3.9"
services: 
  build: .
  ports: 
    - "8000:80"
  depends_on:
  - db
  environment:
  - ASPNETCORE_ENVIRONMENT=Development
  - ConnectionStrings_DefaultConnection=Server=DESKTOP-F7M6I8G\\SQLEXPRESS;Database=Starbucks;User Id=lizzymr;Password=pass1234*
  db:
    image: "mcr.microsoft.com/mssql/server:2019-latest"
    environment:
      - ACCEPT_EULA=Y
      - PASS=pass1234*
    ports:
    - "1433:1433"
    volumes:
    - mssqldata: /var/opt/mssql
  volumes:
    mssqldata  
```

MiStarbucksDbContext.cs
```cs
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Data;

public class MiStarbucksDbContext : DbContext
{
    
}
```
app.js
```js
const express = require('express');

const app = express();

const PORT = process.env.PORT || 3000;

app.get('/', (req, res) =>{
    res.send("¡Hola mundo desde Docker! \n De: Lizeth Martinez");
});

app.listen(PORT, () =>{
    console.log(`Servidor de Node escuchando en el puerto ${PORT}`);
});
```

## Desafíos Encontrados

- **Sin impedimentos:** Por el momento no tuve ningún inconveniente al realizar esta actividad.  

## Recursos Adicionales

- Vmware vSphere 8: ESXi y vCenter desde cero a avanzado.
- Introducción a Docker para principiantes.
- Docker, de principiante a experto.
- Curso práctico de Docker y Microservicios (apto para todos).
- Curso completo de Docker de cero a experto.
- Kubernetes al completo.
- Kubernetes para Desarrolladores.

## Próximos Pasos

- Continuar los avances en cursos de Udemy. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a aprender y recordar temas sobre los contenedores. 

---

*Entregable correspondiente a la Semana 14 del Módulo 4: Kubernetes*