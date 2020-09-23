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
            NetworkNode node = NetworkNode.FromProperties(new Dictionary<string, string>() {
                {"address", "192.0.0.1"},
                {"ports", "12,34,443"},
                {"type", "computer"},
            });
            NetworkLink link = NetworkLink.FromProperties(new Dictionary<string, string>() {
                {"source", "192.0.0.1"},
                {"dest", "12,34,443"},
            });
            NetworkLink link2 = NetworkLink.FromProperties(new Dictionary<string, string>() {
                {"source", "142.32.0.1:80"},
                {"dest", "92.233.255.0"},
            });
            var svgNode = new SVGNode()
            {
                Properties = new Dictionary<string, string>() {
                {"source", "32.0.1:80"},
                {"dest", "92.255.0"},
            }
            };
            var net = new Network()
            {
                Nodes = new NetworkNode[] { node, },
                Links = new NetworkLink[] { link, link2, NetworkLink.FromProperties(svgNode.Properties) }
            };
            return net;
        }
    }
}
