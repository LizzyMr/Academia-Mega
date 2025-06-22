using ChatServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddSingleton<ChatHub>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<ChatServiceImp>();
app.MapGet("/", () =>
    "gRPC Chat - Bienvenido");

app.Run();
