using System.Collections.Generic;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Interface
{
    public interface ICountryBLL
    {
        List<CountryDTO> GetAll();
        void Add(CountryDTO country);
        void Edit(List<CountryDTO> data);
        void Delete(int id);

    }
}