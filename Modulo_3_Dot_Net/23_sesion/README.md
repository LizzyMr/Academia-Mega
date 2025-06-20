# Sesión 23: ASP.NET y C#

## Fecha: 11/06/2025

## Objetivos de la Sesión

- Introducción a ASP.NET y C#

## Temas Cubiertos

1. **Fundamentos de C#**
   - Archivos y manejo de archivos de texto
   - Serialización JSON
   - Serialización XML
   - Introducción a Bases de Datos y Entity Framework Core
   - Consultas y Operaciones CRUD con Entity Framework

## Ejercicios Realizados

### Ejercicio 23: ChatServer y ChatCLient

#### ChatServer:
ChatServer.csproj
```cs
  <ItemGroup>
    <Protobuf Include="Protos/chat.proto" GrpcServices="Server" />
  </ItemGroup>
```

chat.proto: 
```proto 
syntax = "proto3";

option csharp_namespace = "GrpcChat";

package chat;

//Mensaje enviado por cada usuario
message = ChatMessage{
  string user = 1;
  string text = 2;
  int64 = timestamp = 3;
}

//Este es el que nos hace la conexión bidireccional
service ChatService{
  rpc Chat(stream ChatMessage) returns (stream ChatMessage);
}
```

ChatHub.cs
```c#
using System.Collections.Concurrent;
using GrpcChat;

namespace ChatServer.Services;

///<summary>
/// Gestiona las conexiones y reenvia los mensajes
///</summary>
public class ChatHub
{
    private readonly ConcurrentDictionary<string, IServerStreamWriter<ChatMessage>>
        _streams = new();

    public void Join(string user, IServerStreamWriter<ChatMessage> stream)
        => _streams[user] = stream;

    public void Leave(string user)
        => _streams.TryRemove(user, out _);

    public async Task BroadcastAsync(ChatMessage msg, CancellationToken ct)
    {
        foreach (var item in _streams)
        {
            if (ct.IsCancellationRequest) break;
            await item.Value.WriteAsync(msg);
        }
    }
}
```

ChatServiceImp.cs
```cs
using Grpc.Core;
using GrpcChat;

namespace ChatServer.Services;

public class ChatServiceImp : ChatService.ChatServiceBase
{
    private readonly ChatHub _hub;
    private readonly ILogger<ChatServiceImp> _log;

    public ChatServiceImp(ChatHub hub, ILogger<ChatServiceImp> log)
        => (_hub, _log) = (hub, log);
}
```

Program.cs
```cs
using ChatServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddSingleton<ChatHub>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
```

#### ChatClient:

ChatClient.csproj
```cs
  <ItemGroup>
    <Protobuf Include="Protos/chat.proto" GrpcServices="Server" />
  </ItemGroup>
```


## Desafíos Encontrados

- **Sin Impedimentos:** Para esta actividad no tuve ningún problema.


## Recursos Adicionales

- Curso Completo de Programación C Sharp (C#)
- Aprende a programar desde cero con C#, Microsoft .NET y WPF
- Curso de C#
- Desarrollo web full stack: C# + ASP.NET + React + SqlServer

## Próximos Pasos

- Continuar los avances en cursos de Udemy. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales



---

*Entregable correspondiente a la Semana 12 del Módulo 3: ASP.NET y C#*