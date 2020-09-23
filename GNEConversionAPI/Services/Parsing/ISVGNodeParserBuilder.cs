using GNEConversionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNEConversionAPI.Services.Parsing
{
    public interface ISVGNodeParserBuilder
    {
        public void Reset();
        public SVGNodeParser getResult();
        public void SetNodeXpath(string xpath);
        public void SetProperties(IEnumerable<SVGNodePropertyDescription>);
        public void SetCompulsoryProperties();
    }
}
