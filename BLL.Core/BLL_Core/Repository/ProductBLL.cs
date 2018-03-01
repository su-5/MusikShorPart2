using System;
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
            List<Product> productList = _dalFactory.Product.GetAll().Where(w => w.DateDelete == null).OrderBy(x => x.Name).ToList();
            var result = Mapper.Map<List<Product>, List<ProductDTO>>(productList);
            return result;
        }

        public void Add(ProductDTO product)

        {
            Product result = Mapper.Map<ProductDTO, Product>(product);
            _dalFactory.Product.Add(result);
        }

        public void Edit(List<ProductDTO> data)
        {
            foreach (ProductDTO product in data)
            {
                Product result = Mapper.Map<ProductDTO, Product>(product);
                _dalFactory.Product.UpdateVoid(result, result.Id);
            }
        }

        public void Delete(int id)
        {
            var entity = _dalFactory.Product.GetById(id);
            entity.DateDelete = DateTime.Now;
            _dalFactory.Product.UpdateVoid(entity, entity.Id);
        }
    }
}