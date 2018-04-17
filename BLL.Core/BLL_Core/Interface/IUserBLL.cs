using System.Collections.Generic;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Interface
{
    public interface IUserBLL
    {
        List<AppUserDto> GetAll();
        void Add(AppUserDto user);
        void Edit(List<AppUserDto> data);
        void Delete(int id);
        string GetUserName(string mail);
    }
}