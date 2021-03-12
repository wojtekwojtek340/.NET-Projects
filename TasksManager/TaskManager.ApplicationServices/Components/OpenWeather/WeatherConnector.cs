using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;


namespace TaskManager.ApplicationServices.Components.OpenWeather
{
    public class WeatherConnector : IWeatherConnector
    {
        private readonly RestClient restClient;
        private readonly string baseUrl = "https://api.openweathermap.org/";
        private readonly string apiKey = "d34fbf13a041418ed5782c896903f4b5";

        public WeatherConnector()
        {
            this.restClient = new RestClient(baseUrl);
        }
        public async Task<Weather> Fetch(string city)
        {
            var request = new RestRequest("data/2.5/weather", Method.GET);
            request.AddParameter("q", city);
            request.AddParameter("APPID", this.apiKey);
            var queryResult = await restClient.ExecuteAsync(request);
            var weather = JsonConvert.DeserializeObject<Weather>(queryResult.Content);
            return weather;
        }
    }
}
