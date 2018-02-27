using System;
using System.Collections.Generic;
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
        public IHttpActionResult Edit(List<Subcategory> data)
        {
            foreach (var editSubcategory in data)
            {
                var objectSubcategory = _db.Subcategories.Find(editSubcategory.Id);
                if (objectSubcategory == null) continue;
                objectSubcategory.Name = editSubcategory.Name;
                objectSubcategory.Description = editSubcategory.Description;
                objectSubcategory.CategoriesId = editSubcategory.CategoriesId;
                _db.Entry(objectSubcategory).State = System.Data.Entity.EntityState.Modified;
            }

            _db.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var objectSubcategory = _db.Subcategories.Find(id);
            if (objectSubcategory == null) return Ok();
            objectSubcategory.DeleteDate = DateTime.Now;
            _db.Entry(objectSubcategory).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return Ok();
        }

    }
}