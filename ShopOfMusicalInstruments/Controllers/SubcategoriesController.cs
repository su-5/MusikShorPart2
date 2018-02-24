using System.Linq;
using System.Web.Http;
using DAL.Core;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    public class SubcategoriesController : ApiController
    {
        private readonly MusicDataBaseEntities _db = new MusicDataBaseEntities();
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _db.Subcategories.OrderBy(x => x.Category.Name).ThenBy(s=>s.Name).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Add(Subcategory subcategory)
        {
            _db.Subcategories.Add(subcategory);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Subcategory subcategory)
        {
            Subcategory objectSubcategory = _db.Subcategories.Find(id);
            if (objectSubcategory != null)
            {
                objectSubcategory.Name = objectSubcategory.Name;
                objectSubcategory.Description = objectSubcategory.Description;
                objectSubcategory.CategoriesId = objectSubcategory.CategoriesId;
                _db.Entry(objectSubcategory).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return Ok(objectSubcategory);
            }

            return NotFound();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Subcategory objectSubcategory = _db.Subcategories.Find(id);
            if (objectSubcategory != null)
            {
                _db.Subcategories.Remove(objectSubcategory);
                _db.SaveChanges();
            }

            return Ok();
        }
    }
}