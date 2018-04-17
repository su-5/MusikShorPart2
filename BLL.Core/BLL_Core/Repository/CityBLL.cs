using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Core.BLL_Core.Interface;
using DAL.Core;
using DAL.Core.DAL_Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Repository
{
    public class CityBLL:ICityBLL
    {
        private readonly DalFactory _dalFactory;

        public CityBLL(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }

        public List<CityDTO> GetCityByRegion(int id)
        {
            List<City> cityList = _dalFactory.City.GetAll().Where(w => w.RegionId == id).OrderBy(x => x.Name).ToList();
            var result = Mapper.Map<List<City>, List<CityDTO>>(cityList);
            return result;
        }
    }
}