using GNEConversionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNEConversionAPI.Services.Parsing
{
    public class NetworkLinkParserBuilder : ISVGNodeParserBuilder
    {
        private SVGNodeParser Result;
        public NetworkLinkParserBuilder()
        {
            this.Result = new SVGNodeParser();
        }
        SVGNodeParser ISVGNodeParserBuilder.getResult()
        {
            throw new NotImplementedException();
        }

        void ISVGNodeParserBuilder.Reset()
        {
            this.Result = new SVGNodeParser();
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
