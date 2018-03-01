using System;
using System.Linq;
using System.Web.Http;
using BLL.Core.BLL_Core.Interface;
using DAL.Core;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController  
    {
        private IBLLFactory _bllFactory;

        public ProductController(IBLLFactory bllFactory)
        {
            if (bllFactory == null)
            {
                throw new ArgumentNullException(nameof(bllFactory));
            }

            _bllFactory = bllFactory;
        }

        [HttpGet]
        [Route("GetAllDataBase")]
        public IHttpActionResult GetAllDataBase()
        {
            var result = _bllFactory.ProductBll.GetAll();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllCatalog")]
        public IHttpActionResult GetAllCatalog()
        {
          //  var result = _db.Products.Where(w => w.Window == true).OrderBy(r => r.Brand.Name).ToList();
            return Ok();
        }
    }
}
