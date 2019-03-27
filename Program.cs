using System;
using System.Collections.Generic;
using System.IO;
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
            if(File.Exists(path))
            {
                var oc = new OrderController(new OrderServices(path));
            }
            else
            {
                Console.WriteLine("Plik nie istnieje, nastapi zamkniecie programu");
                Console.ReadKey();
            }
        }
        private static string GetPath()
        {
            Console.WriteLine("Prosze podac sciezke do pliku ze sciezkami do plikow csv/xml/json");
            var path = Console.ReadLine();
            return path;
        }
    }
}
