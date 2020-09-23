using GNEConversionAPI.Models;
using GNEConversionAPI.Services.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNEConversionAPI.Services.Graphviz
{
    public class GraphvizService
    {
        public GraphvizService(SVGParsersService svgParsersService)
        {
            this.svgParsersService = svgParsersService;
        }
        public SVGParsersService svgParsersService { get; set; }
        public Network ParseSVG(string svg, SVGNodeDescription nodeDescription, SVGNodeDescription linkDescription)
        {
            var nodeParser = this.svgParsersService.GetNodeParser(nodeDescription);
            var linkParser = this.svgParsersService.GetLinkParser(linkDescription);
            var svgNodes = nodeParser.ParseAll(svg);
            var svgLinks = linkParser.ParseAll(svg);
            var netNodes = svgNodes.Select(x => NetworkNode.FromProperties(x.Properties));
            var netLinks = svgLinks.Select(x => NetworkLink.FromProperties(x.Properties));
            var network = new Network()
            {
                Nodes = netNodes,
                Links = netLinks
            };
            return network;
        }
    }
}
