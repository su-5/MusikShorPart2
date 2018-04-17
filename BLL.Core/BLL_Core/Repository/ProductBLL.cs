using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
            List<Product> productList = _dalFactory.Product.GetAll().Where(w => w.DateDelete == null && w.NumberProduct != 0).OrderBy(x => x.Name).ToList();
            var result = Mapper.Map<List<Product>, List<ProductDTO>>(productList);
            return result;
        }

        public void Add(ProductDTO product)

        {
            Product result = Mapper.Map<ProductDTO, Product>(product);
            if (result.NumberProduct == 0)
            {
                result.Window = false;
            }
            result.DateCreate = DateTime.Now;
            result.DateDelete = null;
            result.DateUpdate = null;
            _dalFactory.Product.Add(result);
        }

        public void Edit(List<ProductDTO> data)
        {
            foreach (ProductDTO product in data)
            {
                Product result = Mapper.Map<ProductDTO, Product>(product);
                if (result.NumberProduct == 0)
                {
                    result.Window = false;
                }
                result.DateDelete = null;
                _dalFactory.Product.UpdateVoid(result, result.Id);
            }
        }

        public void Delete(int id)
        {
            var entity = _dalFactory.Product.GetById(id);
            entity.DateDelete = DateTime.Now;
            _dalFactory.Product.UpdateVoid(entity, entity.Id);
        }

        public List<ProductDTO> GetProductById(int categoryId, int subcategoryId, bool flag)
        {
            var result = flag ? GetAll().Where(x => x.SubcategoriesId == subcategoryId && x.Subcategory.CategoriesId == categoryId && x.Window != false).ToList() : GetAll().Where(x => x.Window != false).ToList();
            return result;
        }

        public List<CartDto> GetAllToCart(List<dynamic> productsList)
        {
            var result = new List<Product>();
            List<CartDto> resultList = null;
            if (productsList != null)
            {
                foreach (var productId in productsList)
                {
                    string id = productId.id.Value.ToString();
                    result.Add(_dalFactory.Product.GetById(Convert.ToInt32(id)));
                }
                 resultList = Mapper.Map<List<Product>, List<CartDto>>(result);
            }
           
            return resultList;
        }

        public void CookiesRecordDb(CookiesRecordDto data)
        {
            var produkts = GetAllToCart(data.ProductList);
            var user = _dalFactory.User.GetAll().FirstOrDefault(u => u.Email == data.UserMail);
            foreach (var produkt in produkts)
            {
                if (user != null)
                {
                    var searchduplicates = user.UsersProducts.Where(p => p.ProductId == produkt.Id).ToList();
                //        
                    if (searchduplicates.Count == 0)
                    {
                        _dalFactory.UsersProduct.Add(new UsersProduct{UserId = user.Id,DateCreate = DateTime.Now,ProductId = produkt.Id});
                    }
                }

              
            }
        }
    }
}