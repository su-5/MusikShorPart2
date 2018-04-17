using System;
using System.Collections.Generic;
using System.Web.Http;
using BLL.Core.BLL_Core.Interface;
using DAL.Core.ModelDTO;

namespace ShopOfMusicalInstruments.Core.Controllers
{
    public class PaymentSystemController : ApiController
    {
        private IBLLFactory _bllFactory;
        public PaymentSystemController(IBLLFactory bllFactory)
        {
            _bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<PaymentSystemDTO> result = _bllFactory.PaymentSystemBll.GetAll();
            return Ok(result);
        }
    }
}
