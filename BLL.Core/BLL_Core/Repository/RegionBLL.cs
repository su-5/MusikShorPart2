using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Core.BLL_Core.Interface;
using DAL.Core;
using DAL.Core.DAL_Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Repository
{
    public class RegionBLL: IRegionBLL
    {
        private readonly DalFactory _dalFactory;

        public RegionBLL(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }

        public List<RegionDTO> GetRegionByCountry(int id)
        {
            List<Region> regionList = _dalFactory.Region.GetAll().Where(w => w.CountryId == id).OrderBy(x => x.Name).ToList();
            var result = Mapper.Map<List<Region>, List<RegionDTO>>(regionList);
            return result;
        }
    }
}