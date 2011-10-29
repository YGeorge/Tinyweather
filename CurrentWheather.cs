using System;

namespace Tinyweather
{
    public class CurrentWeather
    {
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
        public CurrentWeather() { }

        public CurrentWeather(String lastUpdate,
                                Byte humidity,
                                BarometricPressureState rising,
                                Single pressure,
                                String sunrise,
                                String sunset)
        {
            LastUpdate = lastUpdate;
            Humidity = humidity;
            Rising = rising;
            Pressure = pressure;
            Sunrise = sunrise;
            Sunset = sunset;
        }
    }
}
