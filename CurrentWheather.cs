namespace Tinyweather
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;

    public class CurrentWeather
    {
        #region Variables
        private String _lastUpdate;
        private Byte _humidity;
        private BarometricPressureState _rising;
        private Single _pressure;
        private String _sunrise;
        private String _sunset;
        private String _description;
        private Int16 _code;
        private Int16 _temp;

        public String LastUpdate
        {
            get { return _lastUpdate; }
            set { _lastUpdate = value; }
        }
        public Byte Humidity
        {
            get { return _humidity; }
            set { _humidity = value; }
        }
        public BarometricPressureState Rising
        {
            get { return _rising; }
            set { _rising = value; }
        }
        public Single Pressure
        {
            get { return _pressure; }
            set { _pressure = value; }
        }
        public String Sunrise
        {
            get { return _sunrise; }
            set { _sunrise = value; }
        }
        public String Sunset
        {
            get { return _sunset; }
            set { _sunset = value; }
        }
        public Int16 Temp
        {
            get { return _temp; }
            set { _temp = value; }
        }
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public Int16 Code
        {
            get { return _code; }
            set { _code = value; }
        }
        #endregion
        public CurrentWeather() { }

        /// <summary>
        /// Gets the current wheather information.
        /// </summary>
        /// <returns></returns>
        public void GetWeather(Int32 locationID, UnitsOfTemperature unit)
        {
            HttpWebRequest myReq =
                (HttpWebRequest)WebRequest.Create("http://weather.yahooapis.com/forecastrss?w=" + locationID.ToString() + (unit == UnitsOfTemperature.Celsius ? "&u=c" : "&u=f"));
            myReq.Method = "GET";
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            Stream stream = myResp.GetResponseStream();
            XDocument xmlResponse = XDocument.Load(stream);

            foreach (XElement el in xmlResponse.Root.Elements())
            {
                this.LastUpdate = el.Descendants().Where(e => e.Name.LocalName == "lastBuildDate").FirstOrDefault().Value;
                XElement atm = el.Descendants().Where(e => e.Name.LocalName == "atmosphere").FirstOrDefault();
                this.Humidity = Byte.Parse(atm.Attribute("humidity").Value);
                this.Pressure = Single.Parse(atm.Attribute("pressure").Value.Replace(".", ","));
                this.Rising = (BarometricPressureState)Byte.Parse(atm.Attribute("rising").Value);
                XElement astronomy = el.Descendants().Where(e => e.Name.LocalName == "astronomy").FirstOrDefault();
                this.Sunrise = astronomy.Attribute("sunrise").Value;
                this.Sunset = astronomy.Attribute("sunset").Value;
                XElement condition = el.Descendants().Where(e => e.Name.LocalName == "condition").FirstOrDefault();
                this.Temp = Int16.Parse(condition.Attribute("temp").Value);
                this.Code = Int16.Parse(condition.Attribute("code").Value);
                this.Description = condition.Attribute("text").Value;
            }
            myResp.Close();
            stream.Close();
        }
    }
}
