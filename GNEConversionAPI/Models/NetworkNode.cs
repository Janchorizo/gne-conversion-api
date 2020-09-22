using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GNEConversionAPI.Models
{
    public class NetworkNode
    {
        public NetworkNode() {
            this.Properties = new Dictionary<string, string>();
        }
        public NetworkNode(
                string address,
                IEnumerable<int> ports,
                Dictionary<string, string> properties)
        {
            this.Address = address;
            this.Ports = ports;
            this.Properties = properties;
        }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("ports")]
        public IEnumerable<int> Ports { get; set; }

        [JsonPropertyName("properties")]
        public Dictionary<string, string> Properties { get; set; }
        public static NetworkNode FromProperties(Dictionary<string, string> properties)
        {
            NetworkNode node = new NetworkNode();
            foreach (KeyValuePair<string, string> entry in properties)
            {
                switch (entry.Key)
                {
                    case "address":
                        node.Address = entry.Value;
                        break;
                    case "ports":
                        node.Ports = entry.Value.Split(',').Select(x => int.Parse(x));
                        break;
                    default:
                        if (node.Properties == null)
                        {
                            node.Properties = new Dictionary<string, string>() {
                                {entry.Key, entry.Value}
                            };
                        } else
                        {
                            node.Properties.Add(entry.Key, entry.Value);
                        }
                        break;
                }
            }
            return node;
        }
    }
}
