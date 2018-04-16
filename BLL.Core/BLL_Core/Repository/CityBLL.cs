using BLL.Core.BLL_Core.Interface;
using DAL.Core.DAL_Core;

namespace BLL.Core.BLL_Core.Repository
{
    public class CityBLL:ICityBLL
    {
        private readonly DalFactory _dalFactory;

        public CityBLL(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }
    }
}