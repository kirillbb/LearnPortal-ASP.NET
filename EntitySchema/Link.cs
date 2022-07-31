using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal
{
    internal class Link : Material
    {
        public DateTime PublicationDate { get; set; }
        public string? Source { get; set; }
    }
}
