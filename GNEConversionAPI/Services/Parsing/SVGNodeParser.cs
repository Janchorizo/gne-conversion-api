using GNEConversionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GNEConversionAPI.Services.Parsing
{
    public class SVGNodeParser
    {
        private string Xpath;
        private IEnumerable<SVGNodePropertyDescription> Properties;
        private IEnumerable<string> CompulsoryProperties;
        public void SetXpath(string xpath) {
            this.Xpath = xpath;
        }
        public void SetProperties(IEnumerable<SVGNodePropertyDescription> properties) {
            this.Properties = properties;
        }
        public void SetCompulsoryProperties(IEnumerable<string> compulsoryPropertyNames) {
            this.CompulsoryProperties = compulsoryPropertyNames;
        }
        private bool HasCompulsoryProperties(Dictionary<string, string> properties) { }
        public IEnumerable<SVGNode> ParseAll(string svg) { }
        private Dictionary<string, string> GetProperties(XMLNode node) { }
        private string GetProperty(XmlNode node, SVGNodePropertyDescription property) { }
        private IEnumerable<SVGNode> GetNodes(string svg) { }
    }
}
