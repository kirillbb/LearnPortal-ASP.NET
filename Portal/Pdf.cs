using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal
{
    internal class Pdf : Material
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Pages { get; set; }
    }
}
