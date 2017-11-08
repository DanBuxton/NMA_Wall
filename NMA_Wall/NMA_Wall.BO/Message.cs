using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMA_Wall.BO
{
    public class Message
    {
        public Guid Id { get; protected set; }
        public string MessageBody { get; set; }
        public string ImagePath
        {
            get
            {
                return Path.Combine(Settings.RootPathOfWebsite, $@"img\Comments\{Id}.jpg");
            }
        }

        public bool HasImage
        {
            get
            {
                return File.Exists(ImagePath);
            }
        }
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }

        public bool IsAwaitingModeration { get; set; }

        public DateTime DateAdded { get; private set; }

        public Message(string message, double lat, double lon,
            bool hasImage = false, bool isAwaitingModeration = true) : this()
        {
            Id = Guid.NewGuid();
            MessageBody = message;
            Latitude = lat;
            Longitude = lon;

            IsAwaitingModeration = isAwaitingModeration;
        }

        protected Message()
        {
            DateAdded = DateTime.Now;
        }

        public void SaveImage(Stream fileContent)
        {
            byte[] imageBinary = new byte[fileContent.Length];
            fileContent.Read(imageBinary, 0, (int)fileContent.Length);

            System.IO.File.WriteAllBytes(
                ImagePath,
                imageBinary);
        }
    }
}
