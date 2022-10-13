using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable2
{
    class Location
    {
        private int lat;
        private int lon;
        private string road;

        public Location(int lat, int lon, string road)
        {
            this.lat = lat;
            this.lon = lon;
            this.road = Road;
        }

        public int Lat { get { return lat; } }
        public int Lon { get { return lon; } }
        public string Road { get { return road; } }

    }
}
