using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMA_Wall.BO
{
    public static class GeoLocationHelper
    {
        public static double Distance(double fromLatitude, double fromLongitude, double toLatitude, double toLongitude, char unit = 'K')
        {
            double theta = fromLongitude - toLongitude;
            double dist = Math.Sin(DegreeToRadian(fromLatitude)) * Math.Sin(DegreeToRadian(toLatitude)) + Math.Cos(DegreeToRadian(fromLatitude)) * Math.Cos(DegreeToRadian(toLatitude)) * Math.Cos(DegreeToRadian(theta));
            dist = Math.Acos(dist);
            dist = RadianToDegree(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }

        public static double DegreeToRadian(double angle) { return Math.PI * angle / 180.0; }

        public static double RadianToDegree(double angle) { return 180.0 * angle / Math.PI; }
    }
}
