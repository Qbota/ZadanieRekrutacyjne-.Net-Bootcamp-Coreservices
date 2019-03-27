using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Models;

namespace ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Services
{
    public interface IOrderServices
    {
        List<Order> GetOrders();
        List<Order> GetOrders(string clientId);
        int GetOrdersCount();
        int GetOrdersCount(string clientId);
        double GetTotalCost();
        double GetTotalCost(string clientId);
        double GetAverageCost();
        double GetAverageCost(string clientId);
        List<Order> GetOrdersBetweenPrices(double min, double max);
        void GetOrdersGroupedByName();
        void GetOrdersGroupedByName(string clientId);
        List<Order> SortListByKey(List<Order> list, int key);
        void SaveListToCsv(List<Order> list, string path);
        void SaveOperationResultToCsv(double result, string path, int operationType);
        void SaveOperationResultToCsv(double result, string path, int operationType, string clientId);
        void SaveOrdersGroupedByName(string path);
        void SaveOrdersGroupedByName(string path, string clientId);
    }
}
