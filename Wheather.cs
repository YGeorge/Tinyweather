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
        String _locationID;
        String LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }

        /// <summary>
        /// Weather constructor.
        /// </summary>
        /// <returns></returns>
        public Weather(String locationID)
        {
            LocationID = locationID;
        }

        /// <summary>
        /// Gets the current wheather information.
        /// </summary>
        /// <returns></returns>
        public CurrentWeather GetCurrentWeather()
        {
            HttpWebRequest myReq =
                (HttpWebRequest)WebRequest.Create("http://weather.yahooapis.com/forecastrss?w=" + LocationID + "&u=c"); // change to &u=f for Fahrenheit
            myReq.Method = "GET";
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            Stream stream = myResp.GetResponseStream();
            XDocument xmlResponse = XDocument.Load(stream);

            CurrentWeather currentWeather = new CurrentWeather();
            foreach (XElement el in xmlResponse.Root.Elements())
            {
                currentWeather.LastUpdate = el.Descendants().Where(e => e.Name.LocalName == "lastBuildDate").FirstOrDefault().Value;
                XElement atm = el.Descendants().Where(e => e.Name.LocalName == "atmosphere").FirstOrDefault();
                currentWeather.Humidity = Byte.Parse(atm.Attribute("humidity").Value);
                currentWeather.Pressure = Single.Parse(atm.Attribute("pressure").Value.Replace(".",","));
                currentWeather.Rising = (BarometricPressureState)Byte.Parse(atm.Attribute("rising").Value);
                XElement astronomy = el.Descendants().Where(e => e.Name.LocalName == "astronomy").FirstOrDefault();
                currentWeather.Sunrise = astronomy.Attribute("sunrise").Value;
                currentWeather.Sunset = astronomy.Attribute("sunset").Value;
                XElement condition = el.Descendants().Where(e => e.Name.LocalName == "condition").FirstOrDefault();
                currentWeather.Temp = Int16.Parse(condition.Attribute("temp").Value);
                currentWeather.Code = Int16.Parse(condition.Attribute("code").Value);
                currentWeather.Description = condition.Attribute("text").Value;
            }
            myResp.Close();
            stream.Close();
            return currentWeather;
        }

        /// <summary>
        /// Gets the list of wheather forecasts.
        /// </summary>
        /// <returns></returns>
        public List<Forecast> GetForecast()
        {
            HttpWebRequest myReq =
                (HttpWebRequest)WebRequest.Create("http://weather.yahooapis.com/forecastrss?w=" + LocationID + "&u=c");
            myReq.Method = "GET";
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            Stream stream = myResp.GetResponseStream();
            XDocument xmlResponse = XDocument.Load(stream);

            List<Forecast> resultList = new List<Forecast>();
            CurrentWeather currentWheather = new CurrentWeather();
            foreach (XElement el in xmlResponse.Descendants().Where(e => e.Name.LocalName == "forecast"))
            {
                Forecast forecast = new Forecast();
                forecast.LastUpdate = xmlResponse.Descendants().Where(e => e.Name.LocalName == "lastBuildDate").FirstOrDefault().Value;
                forecast.Day = el.Attribute("day").Value;
                forecast.Date = el.Attribute("date").Value;
                forecast.Low = Int16.Parse(el.Attribute("low").Value);
                forecast.High = Int16.Parse(el.Attribute("high").Value);
                forecast.Description = el.Attribute("text").Value;
                forecast.Code = Int16.Parse(el.Attribute("code").Value);

                resultList.Add(forecast);
            }
            myResp.Close();
            stream.Close();
            return resultList;
        }
    }
}