using GNEConversionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNEConversionAPI.Services.Parsing
{
    public class NodeParserDirector
    {
        private ISVGNodeParserBuilder Builder;
        public NodeParserDirector(ISVGNodeParserBuilder builder)
        {
            this.Builder = builder;
        }
        public void ChangeBuilder(ISVGNodeParserBuilder builder)
        {
            this.Builder = builder;
        }
        public void Make(SVGNodeDescription nodeDescription)
        {
            this.Builder.Reset();
            this.Builder.SetNodeXpath(nodeDescription.Xpath);
            this.Builder.SetProperties(nodeDescription.Properties);
            this.Builder.SetCompulsoryProperties();
        }
    }
}
