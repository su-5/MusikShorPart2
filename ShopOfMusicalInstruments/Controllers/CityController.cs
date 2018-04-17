using System;
using System.Collections.Generic;
using System.Web.Http;
using BLL.Core.BLL_Core.Interface;
using DAL.Core.ModelDTO;

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

        [HttpGet]
        [Route("GetCityByRegion")]
        public IHttpActionResult CityByRegion(int id)
        {
            List<CityDTO> result = _bllFactory.CityBll.GetCityByRegion(id);
            return Ok(result);
        }
    }
}
