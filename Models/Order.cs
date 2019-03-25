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
        public string ClientId { get; set; }
        public long RequestId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
