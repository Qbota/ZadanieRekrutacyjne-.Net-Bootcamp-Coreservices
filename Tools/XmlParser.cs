using System;
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
                foreach (XmlNode node in doc.DocumentElement)
                {
                    try
                    {
                        var order = new Order();
                        if(node["clientId"].InnerText.All(x => char.IsLetterOrDigit(x) && !char.IsWhiteSpace(x)) && node["clientId"].InnerText.Length <= 6)
                        {
                            order.ClientId = node["clientId"].InnerText;
                        }
                        else
                        {
                            Console.WriteLine($"Blad w pliku Xml: ClientId ma zly format: {node["clientId"].InnerText}");
                        }
                        order.RequestId = long.Parse(node["requestId"].InnerText);
                        if(node["name"].InnerText.All(x => char.IsLetterOrDigit(x)) && node["name"].InnerText.Length < 255)
                        {
                            order.Name = node["name"].InnerText;
                        }
                        else
                        {
                            Console.WriteLine($"Blad w pliku Xml: Name ma zly format: {node["name"].InnerText}");
                            
                        }
                        order.Quantity = Int32.Parse(node["quantity"].InnerText);
                        order.Price = Double.Parse(node["price"].InnerText, CultureInfo.InvariantCulture);
                        list.Add(order);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Blad w pliku xml: uszkodzone dane " + e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Blad wczytania pliku " + e.Message);
            }
            return list;
        }
    }
}
