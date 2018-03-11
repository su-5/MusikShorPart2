using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BLL.Core.BLL_Core.Interface;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    [RoutePrefix("api/Subcategories")]
    public class SubcategoriesController : ApiController
    {
        private readonly IBLLFactory _bllFactory;
        public SubcategoriesController(IBLLFactory bllFactory)
        {
            _bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
        }
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            List<SubcategoryDTO> result = _bllFactory.SubcategoryBll.GetAll().OrderBy(x => x.Category.Name).ThenBy(s=>s.Name).ToList();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSubcategoryOnCategories")]
        public IHttpActionResult SubcategoryOnCategories(int id)
        {
            List<SubcategoryDTO> result = _bllFactory.SubcategoryBll.GetSubcategoryOnCategories(id);
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