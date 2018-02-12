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
        public static List<Message> Messages = new List<Message>();

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

        private bool valid;
        public bool IsVaild { get { return valid; } set { if (!IsAwaitingModeration) { valid = value; } } }
        public bool IsAwaitingModeration { get; set; }

        public DateTime DateAdded { get; protected set; }

        /// <param name="message">The comment of the user</param>
        /// <param name="lat">Where the user is (latitude)</param>
        /// <param name="lon">Where the user is (longitude)</param>
        /// <param name="isAwaitingModeration">Is the comment required to undergo moderation?</param>
        public Message(string message, double lat, double lon,
            bool isAwaitingModeration = true) : this()
        {
            MessageBody = message;
            Latitude = lat;
            Longitude = lon;

            IsAwaitingModeration = isAwaitingModeration;
        }

        protected Message()
        {
            Id = Guid.NewGuid();
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
