using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    public class ProductController : ApiController  
    {
        private readonly MusicDataBaseEntities _db = new MusicDataBaseEntities();
        public IHttpActionResult GetProduct()
        {
            var result = Mapper.Map<List<Product>, List<ProductDTO>>(_db.Products.ToList());
            return Ok(result);
        }
    }
}
