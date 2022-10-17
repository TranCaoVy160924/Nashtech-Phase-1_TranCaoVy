using Refit;
using CommercialWebSiteClient.Models;

namespace CommercialWebSiteClient.RefitClient
{
    public interface IWeatherForecastClient
    {
        [Get("/WeatherForecast")]
        Task<List<WeatherForecastModel>> GetWeatherForecastAsync();
    }
}
