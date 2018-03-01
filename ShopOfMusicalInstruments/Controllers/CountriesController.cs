using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BLL.Core.BLL_Core.Interface;
using DAL.Core.ModelDTO;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    public class CountriesController : ApiController
    {
        private IBLLFactory _bllFactory;
        public CountriesController(IBLLFactory bllFactory)
        {
            if (bllFactory == null)
            {
                throw new ArgumentNullException(nameof(bllFactory));
            }

            _bllFactory = bllFactory;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _bllFactory.CountryBll.GetAll().OrderBy(x => x.Name).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Add(CountryDTO country)
        {
            _bllFactory.CountryBll.Add(country);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Edit(List<CountryDTO> data)
        {
           _bllFactory.CountryBll.Edit(data);
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _bllFactory.CountryBll.Delete(id);
            return Ok();
        }

    }
}


