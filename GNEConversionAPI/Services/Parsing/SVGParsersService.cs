using GNEConversionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNEConversionAPI.Services.Parsing
{
    public class SVGParsersService
    {
        private NodeParserDirector Director;
        public SVGParsersService() {
            var initialBuilder = new NetworkNodeParserBuilder();
            this.Director = new NodeParserDirector(initialBuilder);
        }
        public SVGNodeParser GetNodeParser(SVGNodeDescription target)
        {
            ISVGNodeParserBuilder nodeParserBuilder = new NetworkNodeParserBuilder();
            this.Director.ChangeBuilder(nodeParserBuilder);
            this.Director.Make(target);
            return nodeParserBuilder.GetResult();
        }
        public SVGNodeParser GetLinkParser(SVGNodeDescription target)
        {
            ISVGNodeParserBuilder linkParserBuilder = new NetworkLinkParserBuilder();
            this.Director.ChangeBuilder(linkParserBuilder);
            this.Director.Make(target);
            return linkParserBuilder.GetResult();
        }
    }
}
