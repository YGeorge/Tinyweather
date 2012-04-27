namespace Tinyweather
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ForecastDay
    {
        private String _day;
        private String _date;
        private Int16 _low;
        private Int16 _high;
        private String _description;
        private Int16 _code;

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

        public ForecastDay() { }
    }
}
