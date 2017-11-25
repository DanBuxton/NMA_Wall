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
        public static List<Message> Messages = new List<Message>
        {
#if DEBUG
            new Message(message: "I love this memorial", lat: 52.800428, lon: -1.630986),
            new Message(message: "I hate this memorial", lat: 52.800428, lon: -1.630986)
#endif
        };

        public Guid Id { get; protected set; }

        public string MessageBody { get; set; }
        public string ImagePath
        {
            get
            {
                return Path.Combine(Settings.RootPathOfWebsite, $@"\img\Comments\{Id}.jpg");
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

        /// <param name="message">The comment of the user</param>
        /// <param name="lat">Where the user is (latitude)</param>
        /// <param name="lon">Where the user is (longitude)</param>
        /// <param name="isAwaitingModeration">Is the comment required to undergo moderation?</param>
        public Message(string message, double lat, double lon,
            bool isAwaitingModeration = true) : this()
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

            File.WriteAllBytes(
                ImagePath,
                imageBinary);
        }
    }
}
