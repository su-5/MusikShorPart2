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
    public class CategoryBLL : ICategoryBLL
    {
        private readonly DalFactory _dalFactory;

        public CategoryBLL(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }

        public List<CategoryDTO> GetAll()
        {
            List<Category> categoryList = _dalFactory.Category.GetAll().Where(w => w.DeleteDate == null).OrderBy(x => x.Name).ToList();
            var result = Mapper.Map<List<Category>, List<CategoryDTO>>(categoryList);
            return result;
        }

        public void Add(CategoryDTO category)
        {
            Category result = Mapper.Map<CategoryDTO, Category>(category);
            result.DeleteDate = null;
            _dalFactory.Category.Add(result);
        }

        public void Edit(List<CategoryDTO> data)
        {
            foreach (CategoryDTO category in data)
            {
                Category result = Mapper.Map<CategoryDTO, Category>(category);
                result.DeleteDate = null;
                _dalFactory.Category.UpdateVoid(result, result.Id);
            }
        }

        public void Delete(int id)
        {
            Category entity = _dalFactory.Category.GetById(id);
            entity.DeleteDate = DateTime.Now;
            _dalFactory.Category.UpdateVoid(entity, entity.Id);
        }
    }
}
