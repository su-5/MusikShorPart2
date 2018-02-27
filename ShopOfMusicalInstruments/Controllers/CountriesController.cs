using System;
using System.Collections.Generic;
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
        public IHttpActionResult Edit(List<Country> data)
        {
            foreach (var editCountry in data)
            {
                var objectCountry = _db.Countries.Find(editCountry.Id);
                if (objectCountry == null) continue;
                objectCountry.Name = editCountry.Name;
                objectCountry.Description = editCountry.Description;
                _db.Entry(objectCountry).State = System.Data.Entity.EntityState.Modified;
            }

            _db.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var objectCountry = _db.Countries.Find(id);
            if (objectCountry == null) return Ok();
            objectCountry.DeleteDate = DateTime.Now;
            _db.Entry(objectCountry).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return Ok();
        }

    }
}


