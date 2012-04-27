namespace Tinyweather
{
    using System;

    public class Location
    {
        private Int32 _locationID;
        public Int32 LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }

        public Location(Int32 locationID)
        {
            _locationID = locationID;
        }
    }
}
