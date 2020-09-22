using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GNEConversionAPI.Models
{
    public class NetworkLink
    {
        public NetworkLink() {
            this.Properties = new Dictionary<string, string>();
        }
        public NetworkLink(
                string sourceAddress,
                string destAddress,
                Dictionary<string, string> properties) {
            this.SourceAddress = sourceAddress;
            this.DestAddress = destAddress;
            this.Properties = properties;
        }

        [JsonPropertyName("source")]
        public string SourceAddress { get; set; }

        [JsonPropertyName("dest")] 
        public string DestAddress { get; set; }

        [JsonPropertyName("properties")]
        public Dictionary<string, string> Properties { get; set; }
        public static NetworkLink FromProperties(Dictionary<string, string> properties)
        {
            NetworkLink link = new NetworkLink();
            foreach (KeyValuePair<string, string> entry in properties)
            {
                switch (entry.Key)
                {
                    case "source":
                        link.SourceAddress = entry.Value;
                        break;
                    case "dest":
                        link.DestAddress = entry.Value;
                        break;
                    default:
                        if (link.Properties == null)
                        {
                            link.Properties = new Dictionary<string, string>() {
                                {entry.Key, entry.Value}
                            };
                        }
                        else
                        {
                            link.Properties.Add(entry.Key, entry.Value);
                        }
                        break;
                }
            }
            return link;
        }
    }
}
