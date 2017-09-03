using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMA_Wall.BO
{
    public class Content
    {
        public Guid Id { get; protected set; }

        public string MainHeading { get; set; }
        public string SubjectHeading { get; set; }
        public string ContentBody { get; set; }

        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }

        public Content(string mainHeading, string subjectHeading, string contentBody,
            double latitude, double longitude) : this()
        {
            MainHeading = mainHeading;
            SubjectHeading = subjectHeading;
            ContentBody = contentBody;

            Latitude = latitude;
            Longitude = longitude;
        }

        public Content()
        {

        }
    }
}
