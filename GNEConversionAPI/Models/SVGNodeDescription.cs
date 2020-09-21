using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace GNEConversionAPI.Models
{
    public class SVGNodeDescription
    {
        public string Xpath { get; set; }
        public IEnumerable<SVGNodePropertyDescription> Properties { get; set;  }
    }
}
