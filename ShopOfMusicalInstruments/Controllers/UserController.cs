using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BLL.Core.BLL_Core.Interface;
using DAL.Core.ModelDTO;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    public class UserController : ApiController
    {
        private IBLLFactory _bllFactory;
        public UserController(IBLLFactory bllFactory)
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
            var result = _bllFactory.UserBll.GetAll().ToList();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Add(AppUserDto user)
        {
            _bllFactory.UserBll.Add(user);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Edit(List<AppUserDto> data)
        {
           _bllFactory.UserBll.Edit(data);
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _bllFactory.UserBll.Delete(id);
            return Ok();
        }

    }
}