using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GNEConversionAPI.Models
{
    public class Network
    {
        [JsonPropertyName("nodes")]
        public IEnumerable<NetworkNode> Nodes { get; set; }

        [JsonPropertyName("links")]
        public IEnumerable<NetworkLink> Links { get; set; }
    }
}
