using BlazorWebAssemblyWithIdentityTypedClient.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWebAssemblyWithIdentityTypedClient.Client
{
    public class WeatherClient
    {
        private readonly HttpClient httpClient;

        public WeatherClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForeacasts()
        {
            IEnumerable<WeatherForecast> forecasts = new WeatherForecast[0];
            try
            {
                forecasts = await httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            return forecasts;
        }
    }
}
