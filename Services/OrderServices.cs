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

namespace ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Services
{
    public class OrderServices : IOrderServices
    {
        private List<Order> _orders;
        private List<string> _pathlist;

        public OrderServices(string path)
        {
            _pathlist = ReadAllPathsFromTxt(path);
            _orders = ParseFilesToOrderList();
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
                        list.AddRange(ParseFromXml(path));
                    }
                    else if (path.Contains(".json"))
                    {
                        list.AddRange(ParseFromJson(path));
                    }
                    else if (path.Contains(".csv"))
                    {
                        list.AddRange(ParseFromCsv(path));
                    }
                }
            }
            return list;
        }
        
        private List<Order> ParseFromCsv(string path)
        {
            return new List<Order>();
        }

        private List<Order> ParseFromJson(string path)
        {
            return new List<Order>();
        }

        private List<Order> ParseFromXml(string path)
        {
            var list = new List<Order>();
            var doc = new XmlDocument();
            doc.LoadXml(String.Concat(File.ReadAllLines(path)));
            foreach(XmlNode node in doc.DocumentElement)
            {
                var order = new Order();
                order.ClientId = node["clientId"].InnerText;
                order.RequestId = Int32.Parse(node["requestId"].InnerText);
                order.Name = node["name"].InnerText;
                order.Quantity = Int32.Parse(node["quantity"].InnerText);
                order.Price = Double.Parse(node["price"].InnerText, CultureInfo.InvariantCulture);
                list.Add(order);
            }
            return list;
        }
     
        
    }
}
