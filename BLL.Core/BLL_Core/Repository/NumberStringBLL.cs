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
    public class NumberStringBLL : INumberStringBLL
    {
        private readonly DalFactory _dalFactory;

        public NumberStringBLL(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }

        public List<NumberStringDTO> GetAll()
        {
            List<NumberString> numberStringList = _dalFactory.NumberString.GetAll().Where(w => w.DeleteDate == null).OrderBy(x => x.Number).ToList();
            var result = Mapper.Map<List<NumberString>, List<NumberStringDTO>>(numberStringList);
            return result;
        }

        public void Add(NumberStringDTO numberString)
        {
            NumberString result = Mapper.Map<NumberStringDTO, NumberString>(numberString);
            _dalFactory.NumberString.Add(result);
        }

        public void Edit(List<NumberStringDTO> data)
        {
            foreach (NumberStringDTO numberString in data)
            {
                NumberString result = Mapper.Map<NumberStringDTO, NumberString>(numberString);
                _dalFactory.NumberString.UpdateVoid(result, result.Id);
            }
        }

        public void Delete(int id)
        {
            var entity = _dalFactory.NumberString.GetById(id);
            entity.DeleteDate = DateTime.Now;
            _dalFactory.NumberString.UpdateVoid(entity, entity.Id);
        }
    }
}
