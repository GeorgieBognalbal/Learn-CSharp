using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialProject.Weather
{
    public class WeatherModel
    {
        public class WeatherResponse
        {
            public MainInfo Main { get; set; }
            public Weather[] Weather { get; set; }
            public string Name { get; set; }
        }

        public class MainInfo
        {
            public float Temp { get; set; }
            public int Humidity { get; set; }
        }

        public class Weather
        {
            public string Description { get; set; }
        }

    }
}
