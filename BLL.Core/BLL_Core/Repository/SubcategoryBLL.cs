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
    public class SubcategoryBLL : ISubcategoryBLL
    {
        private readonly DalFactory _dalFactory;

        public SubcategoryBLL(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }

        public List<SubcategoryDTO> GetAll()
        {
            List<Subcategory> subcategoryList = _dalFactory.Subcategory.GetAll().Where(w => w.DeleteDate == null).OrderBy(x => x.Name).ToList();
            var result = Mapper.Map<List<Subcategory>, List<SubcategoryDTO>>(subcategoryList);
            return result;
        }

        public void Add(SubcategoryDTO subcategory)
        {
            Subcategory result = Mapper.Map< SubcategoryDTO, Subcategory>(subcategory);
            _dalFactory.Subcategory.Add(result);
        }

        public void Edit(List<SubcategoryDTO> data)
        {
            foreach (SubcategoryDTO subcategory in data)
            {
                Subcategory result = Mapper.Map<SubcategoryDTO, Subcategory>(subcategory);
                _dalFactory.Subcategory.UpdateVoid(result, result.Id);
            }
        }

        public void Delete(int id)
        {
            var entity = _dalFactory.Subcategory.GetById(id);
            entity.DeleteDate = DateTime.Now;
            _dalFactory.Subcategory.UpdateVoid(entity, entity.Id);
        }
    }
}
