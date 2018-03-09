using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BLL.Core.BLL_Core.Interface;
using DAL.Core.ModelDTO;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    public class CategoriesController : ApiController
    {
        private IBLLFactory _bllFactory;
        public CategoriesController(IBLLFactory bllFactory)
        {
            _bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _bllFactory.CategoryBll.GetAll().OrderBy(x => x.Name).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Add(CategoryDTO category)
        {
            _bllFactory.CategoryBll.Add(category);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Edit(List<CategoryDTO> data)
        {
            _bllFactory.CategoryBll.Edit(data);
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _bllFactory.CategoryBll.Delete(id);
            return Ok();
        }

    }
}