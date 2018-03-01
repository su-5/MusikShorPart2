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
    public class CountryBLL : ICountryBLL
    {
        private readonly DalFactory _dalFactory;

        public CountryBLL(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }

        public List<CountryDTO> GetAll()
        {
            List<Country> countryList = _dalFactory.Country.GetAll().Where(w => w.DeleteDate == null).OrderBy(x => x.Name).ToList();
            var result = Mapper.Map<List<Country>, List<CountryDTO>>(countryList);
            return result;
        }

        public void Add(CountryDTO country)
        {
            Country result = Mapper.Map<CountryDTO, Country>(country);
            _dalFactory.Country.Add(result);
        }

        public void Edit(List<CountryDTO> data)
        {
            foreach (CountryDTO country in data)
            {
                Country result = Mapper.Map<CountryDTO, Country>(country);
                _dalFactory.Country.UpdateVoid(result, result.Id);
            }
        }

        public void Delete(int id)
        {
            var entity = _dalFactory.Country.GetById(id);
            entity.DeleteDate = DateTime.Now;
            _dalFactory.Country.UpdateVoid(entity, entity.Id);
        }
    }
}
