using System;

namespace Tinyweather
{
    public class Forecast
    {
        private String _lastUpdate;
        private String _day;
        private String _date;
        private Int16 _low;
        private Int16 _high;
        private String _description;
        private Int16 _code;

        public String LastUpdate
        {
            get { return _lastUpdate; }
            set { _lastUpdate = value; }
        }
        public String Day
        {
            get { return _day; }
            set { _day = value; }
        }
        public String Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public Int16 Low
        {
            get { return _low; }
            set { _low = value; }
        }
        public Int16 High
        {
            get { return _high; }
            set { _high = value; }
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

        public Forecast() { }
        public Forecast(String lastUpdate,
                        String day,
                        String date,
                        Int16 low,
                        Int16 high,
                        String description,
                        Int16 code)
        {
            LastUpdate = lastUpdate;
            Day = day;
            Date = date;
            Low = low;
            High = high;
            Description = description;
            Code = code;
        }
    }
}
