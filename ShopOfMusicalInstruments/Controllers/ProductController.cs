using System.Linq;
using System.Web.Http;
using DAL.Core;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    public class ProductController : ApiController  
    {
        private readonly MusicDataBaseEntities _db = new MusicDataBaseEntities();
        public IHttpActionResult GetAll()
        {
            var result = _db.Products.ToList();
            return Ok(result);
        }
    }
}
