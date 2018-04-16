using System;
using System.Collections.Generic;
using System.Web.Http;
using BLL.Core.BLL_Core.Ex;
using BLL.Core.BLL_Core.Interface;
using DAL.Core.ModelDTO;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    [RoutePrefix("api/Cart")]
    public class CartController : ApiController
    {
        private IBLLFactory _bllFactory;

        public CartController(IBLLFactory bllFactory)
        {
            _bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
        }

        [Route("GetAllToCart")]
        [HttpPost]
        public IHttpActionResult GetAllToCart(List<dynamic> data)
        {
            try
            {
                List<CartDto> result = _bllFactory.ProductBll.GetAllToCart(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error",ex.Message);
                return BadRequest(ModelState);
            }  
            
        }


        [Route("cookiesRecordDb")]
        [HttpPost]
        public IHttpActionResult CookiesRecordDb(List<dynamic> data)
        {
            try
            {
             _bllFactory.ProductBll.CookiesRecordDb(data);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }

        }
    }


}
