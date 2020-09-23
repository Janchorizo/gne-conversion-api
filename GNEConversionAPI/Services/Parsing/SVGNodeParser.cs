using GNEConversionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        private Dictionary<string, string> GetProperties(XmlNode node, XmlNamespaceManager nsmgr) {
            var properties = new Dictionary<string, string>();
            foreach (SVGNodePropertyDescription propertyDescription in this.Properties)
            {
                var value = GetProperty(node, nsmgr, propertyDescription);
                properties.Add(propertyDescription.Name, value);
            }
            return properties;
        }
        private string GetProperty(XmlNode node, XmlNamespaceManager nsmgr, SVGNodePropertyDescription property) {
            var propertyNodes = node.SelectNodes(property.Xpath, nsmgr);
            var propertyValues = new List<string>();
            foreach (XmlNode propertyNode in propertyNodes)
            {
                var textContent = propertyNode.InnerText;
                if (property.Regex.Length > 0)
                {
                    textContent = Regex.Replace(textContent, property.Regex, "");
                }
                propertyValues.Add(textContent);
            }
            var value = string.Join(',', propertyValues);
            return value;
        }
        private IEnumerable<XmlNode> GetNodes(XmlDocument svg, XmlNamespaceManager nsmgr) {
            var xmlNodes = svg.DocumentElement.SelectNodes(this.Xpath, nsmgr);
            var xmlNodeList = new List<XmlNode>();

            foreach (XmlNode node in xmlNodes)
            {
                xmlNodeList.Add(node);
            }

            return xmlNodeList;
        }
        public IEnumerable<SVGNode> ParseAll(string svgContent)
        {
            var svgNodes = new List<SVGNode>();
            try
            {
                XmlDocument svgXmlDocument = new XmlDocument();
                svgXmlDocument.LoadXml(svgContent);
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(svgXmlDocument.NameTable);
                nsmgr.AddNamespace("svg", "http://www.w3.org/2000/svg");
                var xmlNodes = GetNodes(svgXmlDocument, nsmgr);

                foreach (XmlNode node in xmlNodes)
                {
                    var properties = GetProperties(node, nsmgr);
                    var svgNode = new SVGNode()
                    {
                        Properties = properties
                    };
                    svgNodes.Add(svgNode);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return svgNodes;
        }
    }
}
