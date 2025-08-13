FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia solo el .csproj y restaura (para cachear dependencias)
COPY DotNetMinimalAPIDemo.csproj ./
RUN dotnet restore

# Copia todo el código fuente al mismo nivel
COPY . . 

# Publica el proyecto (el .csproj está en /src)
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DotNetMinimalAPIDemo.dll"]
