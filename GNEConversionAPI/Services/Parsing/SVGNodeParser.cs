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
        private bool HasCompulsoryProperties(Dictionary<string, string> properties) {
            return true;
        }
        private Dictionary<string, string> GetProperties(XmlNode node) {
            return new Dictionary<string, string>();
        }
        private string GetProperty(XmlNode node, SVGNodePropertyDescription property) {
            return "";
        }
        private IEnumerable<XmlNode> GetNodes(XmlDocument svg) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(svg.NameTable);
            nsmgr.AddNamespace("svg", "http://www.w3.org/2000/svg");
            var xmlNodes = svg.DocumentElement.SelectNodes(this.Xpath, nsmgr);
            var xmlNodeList = new List<XmlNode>();

            foreach (XmlNode node in xmlNodes)
            {
                xmlNodeList.Add(node);
            }

            return xmlNodeList;
        }
        public IEnumerable<SVGNode> ParseAll(string svg)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(svg);
                var nodes = GetNodes(doc);
                Console.WriteLine(nodes.Count());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            return new SVGNode[] { };
        }
    }
}
