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
                if (path != null && File.Exists(path))
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

        public List<Order> GetOrdersBetweenPrices(double min, double max) => _orders.Where(x => x.Price >= min && x.Price < max).ToList();

        public double GetAverageCost(string clientId)
        {
            return _orders
                .Where(x => x.ClientId == clientId)
                .Sum(x => x.Price)
                / _orders.Where(x => x.ClientId == clientId).Count();
        }


        public void GetOrdersGroupedByName()
        {
           var list = _orders.GroupBy(x => x.Name).Select(y => new { Name = y.Key, Quantity = y.Count() });
           foreach(var item in list)
            {
                Console.WriteLine($"{item.Name} {item.Quantity}");
            }
        }


        public void GetOrdersGroupedByName(string clientId)
        {
            var list = _orders.Where(x => x.ClientId == clientId).GroupBy(x => x.Name).Select(y => new { Name = y.Key, Quantity = y.Count() });
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Name} {item.Quantity}");
            }
        }

        public List<Order> SortListByKey(List<Order> list, int key)
        {
            switch (key)
            {
                case 1:
                    return list.OrderBy(x => x.ClientId).ToList();
                case 2:
                    return list.OrderBy(x => x.RequestId).ToList();
                case 3:
                    return list.OrderBy(x => x.Name).ToList();
                case 4:
                    return list.OrderBy(x => x.Quantity).ToList();
                case 5:
                    return list.OrderBy(x => x.Price).ToList();
            }
            return new List<Order>();
        }

        public void SaveListToCsv(List<Order> list, string path)
        {
            if (!path.Contains(".csv"))
                path = path + ".csv";
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine("Client_Id,Request_id,Name,Quantity,Price");
                foreach(var order in list)
                {
                    writer.WriteLine(order.ToString());
                }
            }
        }

        public void SaveOperationResultToCsv(double result, string path, int operationType)
        {
            if (!path.Contains(".csv"))
                path = path + ".csv";
            try
            {
                using (var writer = new StreamWriter(path))
                {
                    switch (operationType)
                    {
                        case 1:
                            writer.WriteLine($"Liczba zamowien to:,{result}");
                            break;
                        case 3:
                            writer.WriteLine($"Laczna kwota zamowien to:,{result}");
                            break;
                        case 7:
                            writer.WriteLine($"Srednia wartosc zamowienia to:,{result}");
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Blad zapisu " + e.Message);
            }
        }

        public void SaveOperationResultToCsv(double result, string path, int operationType, string clientId)
        {
            if (!path.Contains(".csv"))
                path = path + ".csv";
            try
            {
                using (var writer = new StreamWriter(path))
                {
                    switch (operationType)
                    {
                        case 2:
                            writer.WriteLine("ClientId,Liczba zamowien");
                            writer.WriteLine($"{clientId},{result}");
                            break;
                        case 4:
                            writer.WriteLine("ClientId,Laczna kwota zamowien");
                            writer.WriteLine($"{clientId},{result}");
                            break;
                        case 8:
                            writer.WriteLine("ClientId,Srednia wartosc zamowienia");
                            writer.WriteLine($"{clientId},{result}");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Blad zapisu " + e.Message);
            }
        }

        public void SaveOrdersGroupedByName(string path)
        {
            var list = _orders.GroupBy(x => x.Name).Select(y => new { Name = y.Key, Quantity = y.Count() });
            if (!path.Contains(".csv"))
                path = path + ".csv";
            try
            {
                using(var writer = new StreamWriter(path))
                {
                    writer.WriteLine("Name,Quantity");
                    foreach(var item in list)
                    {
                        writer.WriteLine($"{item.Name},{item.Quantity}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Blad zapisu " + e.Message);
            }

        }

        public void SaveOrdersGroupedByName(string path, string clientId)
        {
            var list = _orders.Where(x => x.ClientId == clientId).GroupBy(x => x.Name).Select(y => new { Name = y.Key, Quantity = y.Count() });
            if (!path.Contains(".csv"))
                path = path + ".csv";
            try
            {
                using (var writer = new StreamWriter(path))
                {
                    writer.WriteLine($"Name,Quantity,Clientid: {clientId}");
                    foreach (var item in list)
                    {
                        writer.WriteLine($"{item.Name},{item.Quantity}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Blad zapisu " + e.Message);
            }
        }
    }
}
