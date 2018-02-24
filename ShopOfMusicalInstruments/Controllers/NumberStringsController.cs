using System.Linq;
using System.Web.Http;
using DAL.Core;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    public class NumberStringsController : ApiController
    {
        private readonly MusicDataBaseEntities _db = new MusicDataBaseEntities();
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _db.NumberStrings.OrderBy(x => x.Number).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Add(NumberString numberString)
        {
            _db.NumberStrings.Add(numberString);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] NumberString numberString)
        {
            NumberString objectNumberString = _db.NumberStrings.Find(id);
            if (objectNumberString != null)
            {
                objectNumberString.Number = numberString.Number;
                _db.Entry(objectNumberString).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return Ok(objectNumberString);
            }

            return NotFound();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            NumberString objectNumberString = _db.NumberStrings.Find(id);
            if (objectNumberString != null)
            {
                _db.NumberStrings.Remove(objectNumberString);
                _db.SaveChanges();
            }
            return Ok(objectNumberString);
        }

    }
}

