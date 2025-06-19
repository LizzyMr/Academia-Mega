using PrimeraAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<UsuarioService>();


//middleware
var keyString = builder.Configuration["JwtKey"];
if (string.IsNullOrWhiteSpace(keyString))
    throw new InvalidOperationException("Falta configurar el jwtKey en appsettings");


var key = Encoding.ASCII.GetBytes(keyString);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*    options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "PrimeraAPI",
        Version = "v1"
    });
});*/

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
    /*c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PrimeraAPI v1");
    c.RoutePrefix = "swagger"; // esto es por si accedes a /swagger/

});*/

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
