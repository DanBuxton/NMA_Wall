using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMA_Wall.BO
{
    public class Content
    {
        public Guid Id { get; set; }
        public string MainHeading { get; set; }
        public string SubjectHeading { get; set; }
        public string ContentBody { get; set; }

        public Content()
        {

        }
    }
}
