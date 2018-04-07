using System;
using System.Web.Http;
using BLL.Core.BLL_Core.Interface;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    public class OrdersController : ApiController
    {
        private IBLLFactory _bllFactory;

        public OrdersController(IBLLFactory bllFactory)
        {
            if (bllFactory == null)
            {
                throw new ArgumentNullException(nameof(bllFactory));
            }

            _bllFactory = bllFactory;
        }
    }
}
