using Refit;
using CommercialWebSiteClient.Models;

namespace CommercialWebSiteClient.RefitClient
{
    public interface IWeatherForecastClient
    {
        [Get("/WeatherForecast")]
        [Headers("Authorization: Bearer")]
        Task<List<WeatherForecastModel>> GetWeatherForecastAsync();
    }
}
