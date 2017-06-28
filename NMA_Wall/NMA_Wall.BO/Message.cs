using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMA_Wall.BO
{
    public class Message
    {
        public Guid Id { get; protected set; }
        public string MessageBody { get; set; }
        public bool HasImage { get; set; }
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }

        public Message()
        {

        }
    }
}
