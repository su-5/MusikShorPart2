using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Core.BLL_Core.Interface;
using DAL.Core;
using DAL.Core.DAL_Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Repository
{
    public class ProductBLL : IProductBLL
    {
        private readonly DalFactory _dalFactory;

        public ProductBLL(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }

        public List<ProductDTO> GetAll()
        {
            var result = Mapper.Map<List<Product>, List<ProductDTO>>(_dalFactory.Product.GetAll().ToList());
            return result;
        }
    }
}