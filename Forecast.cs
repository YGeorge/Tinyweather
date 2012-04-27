using System;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace Tinyweather
{
    public class Forecast
    {
        private String _lastUpdate;
        private List<ForecastDay> _forecastDays = new List<ForecastDay>();

        public String LastUpdate
        {
            get { return _lastUpdate; }
            set { _lastUpdate = value; }
        }

        public List<ForecastDay> ForecastDays
        {
            get { return _forecastDays; }
            set { _forecastDays = value; }
        }

        public Forecast() { }

        public void GetForecast(Int32 locationID, UnitsOfTemperature unit)
        {
            HttpWebRequest myReq =
                (HttpWebRequest)WebRequest.Create("http://weather.yahooapis.com/forecastrss?w=" + locationID.ToString() + (unit == UnitsOfTemperature.Celsius ? "&u=c" : "&u=f"));
            myReq.Method = "GET";
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            Stream stream = myResp.GetResponseStream();
            XDocument xmlResponse = XDocument.Load(stream);

            foreach (XElement el in xmlResponse.Descendants().Where(e => e.Name.LocalName == "forecast"))
            {
                this.LastUpdate = xmlResponse.Descendants().Where(e => e.Name.LocalName == "lastBuildDate").FirstOrDefault().Value;

                ForecastDay forecast = new ForecastDay();
                forecast.Day = el.Attribute("day").Value;
                forecast.Date = el.Attribute("date").Value;
                forecast.Low = Int16.Parse(el.Attribute("low").Value);
                forecast.High = Int16.Parse(el.Attribute("high").Value);
                forecast.Description = el.Attribute("text").Value;
                forecast.Code = Int16.Parse(el.Attribute("code").Value);

                this._forecastDays.Add(forecast);
            }
            myResp.Close();
            stream.Close();
        }
    }
}
