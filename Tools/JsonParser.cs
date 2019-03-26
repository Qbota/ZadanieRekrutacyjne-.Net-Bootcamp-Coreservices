using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Models;

namespace ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Tools
{
    public class JsonParser
    {
        public static List<Order> Parse(string path)
        {
            var list = new Orders();
            using (var reader = new StreamReader(path))
            {
                var json = reader.ReadToEnd();
                list = JsonConvert.DeserializeObject<Orders>(json);
            }
            foreach(var order in list.requests)
            {
                if(!order.ClientId.All(x => char.IsLetterOrDigit(x) && !char.IsWhiteSpace(x)) || order.ClientId.Length > 6)
                {
                    Console.WriteLine($"Blad w pliku Json: ClientId ma zly format: {order.ClientId}");
                    order.ClientId = null;
                }
                if(!order.Name.All(x => char.IsLetterOrDigit(x)) || order.Name.Length > 255)
                {
                    Console.WriteLine($"Blad w pliku Json: Name ma zly format: {order.Name}");
                    order.Name = null;
                }
            }
            return list.requests;
        }
    }
}
