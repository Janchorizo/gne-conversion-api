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
        SVGNodeParser ISVGNodeParserBuilder.GetResult()
        {
            return this.Result;
        }

        void ISVGNodeParserBuilder.Reset()
        {
            this.Result = new SVGNodeParser();
        }

        void ISVGNodeParserBuilder.SetCompulsoryProperties()
        {
            this.Result.SetCompulsoryProperties(new string[] { 
                "source", "dest"
            });
        }

        void ISVGNodeParserBuilder.SetNodeXpath(string xpath)
        {
            this.Result.SetXpath(xpath);
        }

        void ISVGNodeParserBuilder.SetProperties(IEnumerable<SVGNodePropertyDescription> properties)
        {
            this.Result.SetProperties(properties);
        }
    }
}
