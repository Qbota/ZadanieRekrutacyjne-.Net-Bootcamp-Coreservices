using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Models
{
    public class Order
    {
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        [JsonProperty("requestId")]
        public long RequestId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
    }
}
