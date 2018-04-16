using System.Collections.Generic;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Interface
{
    public interface IRegionBLL
    {
        List<RegionDTO> GetRegionByCountry(int id);
    }
}