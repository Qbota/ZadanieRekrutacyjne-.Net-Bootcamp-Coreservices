using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Models;

namespace ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.View
{
    public class MainMenu
    {
        
        public void ShowMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1.Wyswietlanie liczby zamowien");
            Console.WriteLine("2.Wyswietlanie zamowien dla klienta o podanym identyfikatorze");
            Console.WriteLine("3.Laczna kwota zamowien");
            Console.WriteLine("4.Laczna kwota zamowien dla klienta o podanym identyfikatorze");
            Console.WriteLine("5.Lista wszystkich zamowien");
            Console.WriteLine("6.Lista wszystkich zamowien dla klienta o podanym identyfikatorze");
            Console.WriteLine("7.Srednia wartosc zamowienia");
            Console.WriteLine("8.Srednia wartosc zamowienia dla klienta o podanym identyfikatorze");
            Console.WriteLine("9.Ilosc zamowien pogrupowanych po nazwie");
            Console.WriteLine("10.Ilosc zamowien pogrupowanych po nazwie dla klienta o podanym identyfikatorze");
            Console.WriteLine("11.Zamowienia w podanym przedziale cenowym");
            Console.WriteLine("12.Wyjscie");
        }
        public void PresentData(List<Order> orders)
        {
            if (orders.Count != 0)
            {
                Console.WriteLine("ClientId, RequestId, Name, Quantity, Price");
                Console.WriteLine("");
                foreach (var order in orders)
                {
                    Console.WriteLine($"{order.ClientId} {order.RequestId} {order.Name} {order.Quantity} {order.Price} ");
                }
            }
            else
                Console.WriteLine("Brak danych do wyswietlenia");
            
        }
        public void PresentData(int number) => Console.WriteLine($"Wynik operacji to: {number}");
        public void PresentData(double number) => Console.WriteLine($"Wynik operacji to: {number}");
        public string GetStringInput()
        {
            Console.WriteLine("Prosze podac ciag znakow i zatwierdzic enterem");
            string input = Console.ReadLine();
            return input;
        }
        public int GetChoice(int choiceNumber)
        {
            Console.WriteLine("Dokonaj wyboru poprzez wpisanie opdowiedniej liczby. Decyzcje zatwierdz enterem");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out var choice))
            {
                Console.WriteLine("Wpisano niepoprawna wartosc");
                choice = 0;
            }
            else if (choice > choiceNumber || choice < 1)
            {
                Console.WriteLine("Wpisano niepoprawna wartosc");
                choice = 0;
            }
            else
            {
                return choice;
            }
            while (choice == 0)
            {
                input = Console.ReadLine();
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Wpisano niepoprawna wartosc");
                    choice = 0;
                }
                else if (choice > choiceNumber || choice < 1)
                {
                    Console.WriteLine("Wpisano niepoprawna wartosc");
                    choice = 0;
                }
                else
                {
                    return choice;
                }
            }
            return 0;
        }

        public void MinMaxInfo() => Console.WriteLine("Prosze podac dwie liczby: najpierw dolna granica zakresu, a potem gorna");
        public double GetDoubleInput()
        {
            Console.WriteLine("Dokonaj wyboru poprzez wpisanie liczby zmiennoprzecinkowej. Decyzcje zatwierdz enterem");
            var input = Console.ReadLine();
            if (!double.TryParse(input, out var choice))
            {
                Console.WriteLine("Wpisano niepoprawna wartosc");
                choice = 0;
            }
            else
            {
                return choice;
            }
            while (choice == 0)
            {
                input = Console.ReadLine();
                if (!double.TryParse(input, out choice))
                {
                    Console.WriteLine("Wpisano niepoprawna wartosc");
                    choice = 0;
                }
                else
                {
                    return choice;
                }
            }
            return 0;
        }
    }
}
