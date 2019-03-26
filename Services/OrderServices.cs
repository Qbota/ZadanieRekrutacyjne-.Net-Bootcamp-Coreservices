using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            foreach (var path in _pathlist)
            {
                if (path != null)
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

        public List<Order> GetOrders() => _orders;

        public int GetOrdersCount() => _orders.Count();

        public int GetOrdersCount(string clientId) => _orders.Where(x => x.ClientId == clientId).Count();

        public List<Order> GetOrders(string clientId) => _orders.Where(x => x.ClientId == clientId).ToList();

        public double GetTotalCost() => _orders.Sum(x => x.Price);

        public double GetTotalCost(string clientId) => _orders.Where(x => x.ClientId == clientId).Sum(x => x.Price);

        public double GetAverageCost() => _orders.Sum(x => x.Price) / _orders.Count();

        public double GetAverageCost(string clientId)
        {
            return _orders
                .Where(x => x.ClientId == clientId)
                .Sum(x => x.Price)
                / _orders.Where(x => x.ClientId == clientId).Count();
        }


    }
}
