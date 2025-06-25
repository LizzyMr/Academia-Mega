using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace SkyCast.Services;

/// <summary>
/// Servicio para obtener datos meteorológicos desde la API de OpenWeather.
/// </summary>
public class WeatherService
{
    private readonly HttpClient _http; // Cliente HTTP para hacer peticiones a la API
    private readonly string _key; // Clave de API para autenticarse con OpenWeather
    private const string baseURL = "https://api.openweathermap.org/data/2.5/"; // URL base de la API

    /// <summary>
    /// Inicializa una nueva instancia del <see cref="WeatherService"/>.
    /// </summary>
    /// <param name="http">Instancia de <see cref="HttpClient"/> utilizada para realizar las solicitudes HTTP.</param>
    /// <param name="config">Configuración de la aplicación que contiene la clave de API de OpenWeather.</param>
    public WeatherService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _key = config["OPENWEATHER_KEY"] ?? ""; // Lee la clave desde la configuración
    }

    /// <summary>
    /// Obtiene los datos del clima para una ciudad específica.
    /// </summary>
    /// <param name="city">Nombre de la ciudad.</param>
    /// <returns>Un objeto <see cref="WeatherDto"/> con los datos del clima, o <c>null</c> si no se encuentra la ciudad.</returns>
    public async Task<WeatherDto?> GetByCityAsync(string city)
    {
        // Construye la URL con el nombre de la ciudad, en unidades métricas y lenguaje español
        var url = $"{baseURL}/weather?q={Uri.EscapeDataString(city)}&units=metric&appid={_key}&lang=es";

        // Hace la petición HTTP y deserializa automáticamente la respuesta JSON a WeatherDto
        return await _http.GetFromJsonAsync<WeatherDto>(url);
    }
}

