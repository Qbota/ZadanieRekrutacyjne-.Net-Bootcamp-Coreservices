using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Models;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Tools;

namespace ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly List<Order> _orders;
        private readonly List<string> _pathlist;

        public OrderServices(string path)
        {
            _pathlist = ReadAllPathsFromTxt(path);
            _orders = ParseFilesToOrderList();
            foreach(var order in _orders)
            {
                Console.WriteLine($"{order.ClientId} {order.RequestId} {order.Name} {order.Quantity} {order.Price} ");
            }
            Console.ReadKey();
        }

        private List<string> ReadAllPathsFromTxt(string path)
        {
            var list = new List<string>();
            if (path != null)
            {
                try
                {
                    list = File.ReadAllLines(path).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wystapil blad odczytu pliku tekstowego");
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        
        private List<Order> ParseFilesToOrderList()
        {
            var list = new List<Order>();
            foreach(var path in _pathlist)
            {
                if(path != null)
                {
                    if (path.Contains(".xml"))
                    {
                        list.AddRange(XmlParser.Parse(path));
                    }
                    else if (path.Contains(".json"))
                    {
                        list.AddRange(JsonParser.Parse(path));
                    }
                    else if (path.Contains(".csv"))
                    {
                        list.AddRange(CsvParser.Parse(path));
                    }
                }
            }
            return list;
        }    
    }
}
