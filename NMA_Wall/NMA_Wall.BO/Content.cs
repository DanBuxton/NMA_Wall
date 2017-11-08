using System;
using System.Collections.Generic;
using System.IO;
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

        public DateTime CreatedOn { get; protected set; }

        public double ShowInRadiusOf { get; set; } = 0.1;

        public bool HasImage
        {
            get
            {
                return File.Exists(Path.Combine(Settings.RootPathOfWebsite, $@"img\Content\{Id}.jpg"));
            }
        }

        public Content(string mainHeading, string subjectHeading, string contentBody,
            double latitude, double longitude) : this()
        {
            MainHeading = mainHeading;
            SubjectHeading = subjectHeading;
            ContentBody = contentBody;

            Latitude = latitude;
            Longitude = longitude;
        }

        protected Content()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.Now;
        }

        public void SaveImage()
        {

        }
    }
}
