using System;
using System.Web.Http;
using BLL.Core.BLL_Core.Interface;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    [RoutePrefix("api/Region")]
    public class RegionController : ApiController
    {
        private IBLLFactory _bllFactory;

        public RegionController(IBLLFactory bllFactory)
        {
            _bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
        }
    }
}
