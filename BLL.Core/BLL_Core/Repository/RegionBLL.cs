using BLL.Core.BLL_Core.Interface;
using DAL.Core.DAL_Core;

namespace BLL.Core.BLL_Core.Repository
{
    public class RegionBLL: IRegionBLL
    {
        private readonly DalFactory _dalFactory;

        public RegionBLL(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }
    }
}