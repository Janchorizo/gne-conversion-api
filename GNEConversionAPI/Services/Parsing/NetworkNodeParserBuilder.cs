using GNEConversionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNEConversionAPI.Services.Parsing
{
    public class NetworkNodeParserBuilder : ISVGNodeParserBuilder
    {
        private SVGNodeParser Result;
        SVGNodeParser ISVGNodeParserBuilder.getResult()
        {
            throw new NotImplementedException();
        }

        void ISVGNodeParserBuilder.Reset()
        {
            throw new NotImplementedException();
        }

        void ISVGNodeParserBuilder.SetCompulsoryProperties()
        {
            throw new NotImplementedException();
        }

        void ISVGNodeParserBuilder.SetNodeXpath(string xpath)
        {
            throw new NotImplementedException();
        }

        void ISVGNodeParserBuilder.SetProperties(IEnumerable<SVGNodePropertyDescription> )
        {
            throw new NotImplementedException();
        }
    }
}
