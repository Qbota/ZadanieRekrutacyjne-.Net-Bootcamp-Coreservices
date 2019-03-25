using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Services;

namespace ZadanieRekrutacyjne_.Net_Bootcamp_Coreservices.Controllers
{
    public class OrderController
    {
        private IOrderServices _services; 
        public OrderController(IOrderServices services)
        {
            _services = services;
            
        }

        
    }
}
