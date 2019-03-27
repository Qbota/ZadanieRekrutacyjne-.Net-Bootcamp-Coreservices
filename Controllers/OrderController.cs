using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Models;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Services;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.View;

namespace ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Controllers
{
    public class OrderController
    {
        private IOrderServices _services;
        private MainMenu _menu;
        private enum SortBy { clientId=1, requestId, name, quantity, price };
        public OrderController(IOrderServices services)
        {
            _services = services;
            _menu = new MainMenu();
            Run();
        }
        private void Run()
        {
            var running = true;
            while (running)
            {
                var list = new List<Order>();
                double result = 0;
                var clientId = "";
                _menu.ShowMenu();
                var c = _menu.GetChoice(13);
                switch (c)
                {
                    case 1:
                        result = _services.GetOrdersCount();
                        _menu.PresentData(result);
                        _menu.SaveToFileMessage();
                        if(_menu.GetYesNoInput())
                            _services.SaveOperationResultToCsv(result, _menu.GetStringInput(), c);
                        break;
                    case 2:
                        _menu.PickClientIdMessage();
                        clientId = _menu.GetStringInput();
                        result = _services.GetOrdersCount(clientId);
                        _menu.PresentData(result);
                        _menu.SaveToFileMessage();
                        if (_menu.GetYesNoInput())
                            _services.SaveOperationResultToCsv(result, _menu.GetStringInput(), c, clientId);
                        break;
                    case 3:
                        result = _services.GetTotalCost();
                        _menu.PresentData(result);
                        _menu.SaveToFileMessage();
                        if (_menu.GetYesNoInput())
                            _services.SaveOperationResultToCsv(result, _menu.GetStringInput(), c);
                        break;
                    case 4:
                        _menu.PickClientIdMessage();
                        clientId = _menu.GetStringInput();
                        result = _services.GetTotalCost(clientId);
                        _menu.PresentData(result);
                        _menu.SaveToFileMessage();
                        if (_menu.GetYesNoInput())
                            _services.SaveOperationResultToCsv(result, _menu.GetStringInput(), c, clientId);
                        break;
                    case 5:
                        list = _services.GetOrders();
                        _menu.PresentData(_services.GetOrders());
                        list = _services.SortListByKey(list, DecideSortingKey());
                        _menu.PresentData(list);
                        _menu.SaveToFileMessage();
                        if (_menu.GetYesNoInput())
                            _services.SaveListToCsv(list, _menu.GetStringInput());
                        break;
                    case 6:
                        _menu.PickClientIdMessage();
                        clientId = _menu.GetStringInput();
                        list = _services.GetOrders(clientId);
                        _menu.PresentData(list);
                        list = _services.SortListByKey(list, DecideSortingKey());
                        _menu.PresentData(list);
                        _menu.SaveToFileMessage();
                        if (_menu.GetYesNoInput())
                            _services.SaveListToCsv(list, _menu.GetStringInput());
                        break;
                    case 7:
                        result = _services.GetAverageCost();
                        _menu.PresentData(result);
                        _menu.SaveToFileMessage();
                        if (_menu.GetYesNoInput())
                            _services.SaveOperationResultToCsv(result, _menu.GetStringInput(), c);
                        break;
                    case 8:
                        _menu.PickClientIdMessage();
                        clientId = _menu.GetStringInput();
                        result = _services.GetAverageCost();
                        _menu.PresentData(result);
                        _menu.SaveToFileMessage();
                        if (_menu.GetYesNoInput())
                            _services.SaveOperationResultToCsv(result, _menu.GetStringInput(), c, clientId);
                        break;
                    case 9:
                        _services.GetOrdersGroupedByName();
                        _menu.SaveToFileMessage();
                        if (_menu.GetYesNoInput())
                            _services.SaveOrdersGroupedByName(_menu.GetStringInput());
                        break;
                    case 10:
                        _menu.PickClientIdMessage();
                        clientId = _menu.GetStringInput();
                        _services.GetOrdersGroupedByName();
                        _menu.SaveToFileMessage();
                        if (_menu.GetYesNoInput())
                            _services.SaveOrdersGroupedByName(_menu.GetStringInput(),clientId);
                        break;
                    case 11:
                        _menu.MinMaxInfo();
                        list = _services.GetOrdersBetweenPrices(_menu.GetDoubleInput(), _menu.GetDoubleInput());
                        _menu.PresentData(list);
                        list = _services.SortListByKey(list, DecideSortingKey());
                        _menu.PresentData(list);
                        _menu.SaveToFileMessage();
                        if (_menu.GetYesNoInput())
                            _services.SaveListToCsv(list, _menu.GetStringInput());
                        break;
                    case 12:
                        running = false;
                        break;
                }
            }
        }

        private int DecideSortingKey()
        {
            _menu.SortingMessage();
            if (_menu.GetYesNoInput())
            {
                var key = _menu.GetStringInput().ToLower();
                switch (key)
                {
                    case "clientid":
                        return (int)SortBy.clientId;
                    case "requestid":
                        return (int)SortBy.requestId;
                    case "name":
                        return (int)SortBy.name;
                    case "quantity":
                        return (int)SortBy.quantity;
                    case "price":
                        return (int)SortBy.price;
                    default:
                        Console.WriteLine("Podano bledna wartosc");
                        break;
                }
            }
            return 0;
        }

        
    }
}
