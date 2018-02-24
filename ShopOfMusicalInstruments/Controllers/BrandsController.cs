using System.Collections.Generic;
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
        public IHttpActionResult Edit(List<Brand> data)
        {
            foreach (var editBrand in data)
            {
                var objectBrand = _db.Brands.Find(editBrand.Id);
                if (objectBrand == null) continue;
                objectBrand.Name = editBrand.Name;
                objectBrand.Description = editBrand.Description;
                _db.Entry(objectBrand).State = System.Data.Entity.EntityState.Modified;
            }

            _db.SaveChanges();
            return Ok();
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