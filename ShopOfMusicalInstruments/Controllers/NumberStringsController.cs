using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BLL.Core.BLL_Core.Interface;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    public class NumberStringsController : ApiController
    {
        private IBLLFactory _bllFactory;
        public NumberStringsController(IBLLFactory bllFactory)
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
            var result = _bllFactory.NumberStringBll.GetAll().OrderBy(x => x.Number).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Add(NumberStringDTO numberString)
        {
            _bllFactory.NumberStringBll.Add(numberString);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Edit(List<NumberStringDTO> data)
        {
            _bllFactory.NumberStringBll.Edit(data);
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
           _bllFactory.NumberStringBll.Delete(id);
            return Ok();
        }

    }
}

