using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace SkyCast.Services
{
    /// <summary>
    /// Servicio para obtener datos meteorológicos desde la API de OpenWeather.
    /// </summary>
    public class WeatherService
    {
        private readonly HttpClient _http;
        private readonly string _key;
        private const string baseURL = "https://openweathermap.org/data/2.5/";

        /// <summary>
        /// Inicializa una nueva instancia del <see cref="WeatherService"/>.
        /// </summary>
        /// <param name="http">Instancia de <see cref="HttpClient"/> utilizada para realizar las solicitudes HTTP.</param>
        /// <param name="config">Configuración de la aplicación que contiene la clave de API de OpenWeather.</param>
        public WeatherService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _key = config["OpenWeather.key"] ?? "";
        }

        /// <summary>
        /// Obtiene los datos del clima para una ciudad específica.
        /// </summary>
        /// <param name="city">Nombre de la ciudad.</param>
        /// <returns>Un objeto <see cref="WeatherDto"/> con los datos del clima, o <c>null</c> si no se encuentra la ciudad.</returns>
        public async Task<WeatherDto?> GetByCityAsync(string city)
        {
            var url = $"{baseURL}/weather?q={Uri.EscapeDataString(city)}&units=metric&appid={_key}&lang=es";

            return await _http.GetFromJsonAsync<WeatherDto>(url);
        }
    }
}
