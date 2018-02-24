using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using DAL.Core;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    public class BrandsController : ApiController
    {
        private readonly MusicDataBaseEntities _db = new MusicDataBaseEntities();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _db.Brands.OrderBy(x => x.Name).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Add(Brand brand)
        {
            _db.Brands.Add(brand);
            _db.SaveChanges();
            return Ok(brand);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Brand brand)
        {
            Brand objectBrand = _db.Brands.Find(id);
            if (objectBrand != null)
            {
                objectBrand.Name = brand.Name;
                objectBrand.Description = brand.Description;
                _db.Entry(objectBrand).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return Ok(objectBrand);
            }

            return NotFound();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Brand objectBrand = _db.Brands.Find(id);
            if (objectBrand != null)
            {
                _db.Brands.Remove(objectBrand);
                _db.SaveChanges();
            }
            return Ok(objectBrand);
        }

    }
}