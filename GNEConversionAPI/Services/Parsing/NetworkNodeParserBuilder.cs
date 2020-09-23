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
        public NetworkNodeParserBuilder()
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
                "address", "ports"
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
