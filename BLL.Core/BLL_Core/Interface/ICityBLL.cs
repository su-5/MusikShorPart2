using System.Collections.Generic;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Interface
{
    public interface ICityBLL
    {
        List<CityDTO> GetCityByRegion(int id);
    }
}