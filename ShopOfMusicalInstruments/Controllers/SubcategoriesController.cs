using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BLL.Core.BLL_Core.Interface;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    public class SubcategoriesController : ApiController
    {
        private IBLLFactory _bllFactory;
        public SubcategoriesController(IBLLFactory bllFactory)
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
            var result = _bllFactory.SubcategoryBll.GetAll().OrderBy(x => x.Category.Name).ThenBy(s=>s.Name).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Add(SubcategoryDTO subcategory)
        {
            _bllFactory.SubcategoryBll.Add(subcategory);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Edit(List<SubcategoryDTO> data)
        {
            _bllFactory.SubcategoryBll.Edit(data);           
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
           _bllFactory.SubcategoryBll.Delete(id);
            return Ok();
        }

    }
}