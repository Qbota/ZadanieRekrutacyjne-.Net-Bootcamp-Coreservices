using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Services;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.View;

namespace ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Controllers
{
    public class OrderController
    {
        private IOrderServices _services;
        private MainMenu _menu;
        public OrderController(IOrderServices services)
        {
            _services = services;
            _menu = new MainMenu();
            Run();
        }
        public void Run()
        {
            var running = true;
            while (running)
            {
                _menu.ShowMenu();
                var c = _menu.GetChoice(13);
                switch (c)
                {
                    case 1:
                        _menu.PresentData(_services.GetOrdersCount());
                        break;
                    case 2:
                        _menu.PresentData(_services.GetOrdersCount(_menu.GetStringInput()));
                        break;
                    case 3:
                        _menu.PresentData(_services.GetTotalCost());
                        break;
                    case 4:
                        _menu.PresentData(_services.GetTotalCost(_menu.GetStringInput()));
                        break;
                    case 5:
                        _menu.PresentData(_services.GetOrders());
                        break;
                    case 6:
                        _menu.PresentData(_services.GetOrders(_menu.GetStringInput()));
                        break;
                    case 7:
                        _menu.PresentData(_services.GetAverageCost());
                        break;
                    case 8:
                        _menu.PresentData(_services.GetAverageCost(_menu.GetStringInput()));
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                    case 12:
                        running = false;
                        break;
                }
            }
        }

        
    }
}
