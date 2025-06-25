namespace SkyCast.Services
{
    /// <summary>
    /// Representa los datos meteorológicos principales para una ubicación.
    /// </summary>
    /// <param name="Name">Nombre de la ciudad o ubicación.</param>
    /// <param name="Main">Datos principales del clima (temperatura, humedad, etc.).</param>
    /// <param name="Weather">Lista de condiciones climáticas (descripción, icono, etc.).</param>
    public record WeatherDto(string Name, MainData Main, IEnumerable<WeatherInfo> Weather);

    /// <summary>
    /// Contiene información principal del clima, como la temperatura y la humedad.
    /// </summary>
    /// <param name="Temp">Temperatura actual en grados Celsius.</param>
    /// <param name="Humidity">Porcentaje de humedad relativa.</param>
    public record MainData(double Temp, double Humidity);

    /// <summary>
    /// Representa información específica sobre una condición climática.
    /// </summary>
    /// <param name="Description">Descripción textual del clima (e.g. "cielo claro").</param>
    /// <param name="Icon">Código del icono correspondiente a la condición climática.</param>
    public record WeatherInfo(string Description, string Icon);
}
