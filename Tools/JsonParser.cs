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
            return list.requests;
        }
    }
}
