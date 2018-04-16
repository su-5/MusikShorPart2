using System;
using System.Web.Http;
using BLL.Core.BLL_Core.Interface;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    [RoutePrefix("api/City")]
    public class CityController : ApiController
    {
        private IBLLFactory _bllFactory;

        public CityController(IBLLFactory bllFactory)
        {
            _bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
        }
    }
}
