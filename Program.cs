using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Controllers;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Services;

namespace ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = GetPath();
            if(path != null)
            {
                var oc = new OrderController(new OrderServices(path));
            }
        }
        private static string GetPath()
        {
            Console.WriteLine("Prosze podac sciezke do pliku ze sciezkami do plikow csv/xml/json");
            //var path = Console.ReadLine();
            var path = @"C:\Users\kubac\source\repos\ZadanieRekrutacyjne-.Net-Bootcamp-Coreservices\paths.txt";
            return path;
        }
    }
}
