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
    public class UserBLL:IUserBLL 
    {

        private readonly DalFactory _dalFactory;

        public UserBLL(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }

        public List<AppUserDto> GetAll()
        {
            List<User> userList = _dalFactory.User.GetAll().ToList();
            var result = Mapper.Map<List<User>, List<AppUserDto>>(userList);
            return result;
        }

        public void Add(AppUserDto user)
        {
            User result = Mapper.Map<AppUserDto, User>(user);
            _dalFactory.User.Add(result);
        }

        public void Edit(List<AppUserDto> data)
        {
            foreach (AppUserDto user in data)
            {
                User result = Mapper.Map<AppUserDto, User>(user);
                _dalFactory.User.UpdateVoid(result, Convert.ToDecimal(result.Id));
            }
        }

        public void Delete(int id)
        {
            var entity = _dalFactory.User.GetById(id);
            _dalFactory.User.UpdateVoid(entity, Convert.ToDecimal(entity.Id));
        }
    }
}
