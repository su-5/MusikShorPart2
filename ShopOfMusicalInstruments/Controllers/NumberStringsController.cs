using System;
using System.Collections.Generic;
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
        public IHttpActionResult Edit(List<NumberString> data)
        {
            foreach (var editNumberString in data)
            {
                var objectNumberString = _db.NumberStrings.Find(editNumberString.Id);
                if (objectNumberString == null) continue;
                objectNumberString.Number = editNumberString.Number;
                _db.Entry(objectNumberString).State = System.Data.Entity.EntityState.Modified;
            }

            _db.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var objectNumberString = _db.NumberStrings.Find(id);
            if (objectNumberString == null) return Ok();
            objectNumberString.DeleteDate = DateTime.Now;
            _db.Entry(objectNumberString).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return Ok();
        }

    }
}

