using System;
using System.Collections.Generic;
using System.Web.Http;
using BLL.Core.BLL_Core.Interface;
using DAL.Core.ModelDTO;

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


        [HttpGet]
        [Route("GetRegionByCountry")]
        public IHttpActionResult RegionByContry(int id)
        {
            List<RegionDTO> result = _bllFactory.RegionBll.GetRegionByCountry(id);
            return Ok(result);
        }
    }
}
