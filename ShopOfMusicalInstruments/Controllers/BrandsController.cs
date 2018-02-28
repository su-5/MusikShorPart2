using System;
using System.Collections.Generic;
using System.Web.Http;
using BLL.Core.BLL_Core.Interface;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    public class BrandsController : ApiController
    {
        private IBLLFactory _bllFactory;

        public BrandsController(IBLLFactory bllFactory)
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
            var result = _bllFactory.BrandBll.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Add(BrandDTO brand)
        {
            _bllFactory.BrandBll.Add(brand);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Edit(List<BrandDTO> data)
        {
            _bllFactory.BrandBll.Edit(data);
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _bllFactory.BrandBll.Delete(id);
            return Ok();
        }

    }
}