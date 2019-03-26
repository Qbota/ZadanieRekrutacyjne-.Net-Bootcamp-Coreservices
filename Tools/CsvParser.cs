using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Models;

namespace ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Tools
{
    public class CsvParser
    {
        public static List<Order> Parse(string path)
        {
            var list = new List<Order>();
            using (var reader = new StreamReader(path))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Split(',');
                    var order = new Order();
                    if(line[0].All(x => char.IsLetterOrDigit(x) && !char.IsWhiteSpace(x)) && line[0].Length <= 6)
                    {
                        order.ClientId = line[0];
                    }
                    else
                    {
                        Console.WriteLine($"Blad w pliku csv: ClientId ma zly format: {line[0]}");
                    }
                    if (line[2].All(x => char.IsLetterOrDigit(x)) && line[2].Length < 255)
                    {
                        order.Name = line[2];
                    }
                    else
                    {
                        Console.WriteLine($"Blad w pliku Xml: Name ma zly format: {line[2]}");
                    }
                    order.RequestId = long.Parse(line[1]);
                    order.Quantity = Int32.Parse(line[3]);
                    order.Price = Double.Parse(line[4], CultureInfo.InvariantCulture);
                    list.Add(order);
                }

            }
            return list;
        }
    }
}
