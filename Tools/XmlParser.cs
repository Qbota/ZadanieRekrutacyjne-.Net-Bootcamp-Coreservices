﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Models;

namespace ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Tools
{
    public class XmlParser
    {
        public static List<Order> Parse(string path)
        {
            var list = new List<Order>();
            var doc = new XmlDocument();
            try
            {
                doc.LoadXml(string.Concat(File.ReadAllLines(path)));
            }
            catch (Exception e)
            {
                Console.WriteLine("Blad wczytania pliku " + e.Message);
            }
            foreach (XmlNode node in doc.DocumentElement)
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
