using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace Tinyweather
{
    public class Weather
    {
        Location _location;
        Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

        /// <summary>
        /// Weather constructor.
        /// </summary>
        /// <returns></returns>
        public Weather(Int32 locationID)
        {
            _location = new Location(locationID);
        }

        /// <summary>
        /// Gets the current wheather information.
        /// </summary>
        /// <returns></returns>
        public CurrentWeather GetCurrentWeather()
        {
            CurrentWeather currentWeather = new CurrentWeather();
            currentWeather.GetWeather(_location.LocationID, UnitsOfTemperature.Celsius);
            return currentWeather;
        }

        /// <summary>
        /// Gets the list of wheather forecasts.
        /// </summary>
        /// <returns></returns>
        public Forecast GetForecast()
        {
            Forecast forecast = new Forecast();
            forecast.GetForecast(_location.LocationID, UnitsOfTemperature.Celsius);
            return forecast;
        }
    }
}