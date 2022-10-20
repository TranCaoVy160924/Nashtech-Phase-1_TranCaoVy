using CommercialWebSite.ShareDTO.Business;
using Refit;

namespace CommercialWebSite.Client.RefitClient
{
    public interface IWeatherForecastClient
    {
        [Get("/WeatherForecast")]
        [Headers("Authorization: Bearer")]
        Task<List<WeatherForecastModel>> GetWeatherForecastAsync();
    }
}
