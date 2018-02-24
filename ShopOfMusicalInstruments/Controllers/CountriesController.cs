using System.Linq;
using System.Web.Http;
using DAL.Core;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    public class CountriesController : ApiController
    {
        private readonly MusicDataBaseEntities _db = new MusicDataBaseEntities();
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _db.Countries.OrderBy(x => x.Name).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Add(Country country)
        {
            _db.Countries.Add(country);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Country country)
        {
            Country objectCountry = _db.Countries.Find(id);
            if (objectCountry != null)
            {
                objectCountry.Name = country.Name;
                objectCountry.Description = country.Description;
                _db.Entry(objectCountry).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return Ok(objectCountry);
            }

            return NotFound();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Country objectCountry = _db.Countries.Find(id);
            if (objectCountry != null)
            {
                _db.Countries.Remove(objectCountry);
                _db.SaveChanges();
            }
            return Ok(objectCountry);
        }

    }
}
   