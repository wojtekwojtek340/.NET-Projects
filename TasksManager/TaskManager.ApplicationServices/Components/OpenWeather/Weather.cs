using Newtonsoft.Json;

namespace TaskManager.ApplicationServices.Components.OpenWeather
{
    public class Weather
    {
        [JsonProperty("main")]
        public MainData Main { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}