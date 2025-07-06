# Sesión 04: Kubernetes

## Fecha: 26/06/2025

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

### Ejercicio 04: Ejecución de DemoApp y creación de Aplicación 2

En el siguiente apartado se adjuntaran los archivos modificados para esta actividad, y tambien encontrarás las capturas de Docker Desktops. 

#### DemoApp
docker-compose.yml
```yml
services: 
  app:
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
      - mssqldata:/var/opt/mssql

volumes:
  mssqldata:  
```

Dockerfile
```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY DemoApp.csproj .
RUN dotnet restore DemoApp.csproj
COPY . .
RUN dotnet publish DemoApp.csproj -c Release -o /app 
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app 
COPY --from=build /app .
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT [ "dotnet", "DemoApp.dll" ]
```

#### Aplicacion2
docker-compose.yml
```yml
networks:
  frontnet:
  backnet: 

services:
  web:
    networks:
      - frontnet
      - backnet
  db: 
    networks:
      - backnet  
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