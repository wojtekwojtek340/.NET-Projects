using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskManager.ApplicationServices.Components.OpenWeather
{
    using System.Threading.Tasks;
    public interface IWeatherConnector
    {
        Task<Weather> Fetch(string city);
    }
}
