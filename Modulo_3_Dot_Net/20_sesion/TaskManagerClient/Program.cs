using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TaskManagerClient.Services;
using TaskManagerClient;

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
