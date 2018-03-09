using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Core;
using DAL.Core.ModelDTO;
using Microsoft.AspNet.Identity;

namespace BLL.Core.Identity
{
    public class UserIdentityStore : IUserStore<AppUserDto>, IUserEmailStore<AppUserDto>,
       IUserPasswordStore<AppUserDto>, IUserRoleStore<AppUserDto>
    {
        MusicDataBaseEntities _db = new MusicDataBaseEntities();

        public UserIdentityStore(MusicDataBaseEntities context)
        {
           // _db = context;
        }

        public void Dispose()
        {
        }


        public Task CreateAsync(AppUserDto user)
        {
            //return Task.Factory.StartNew(() =>
            //{
            //    user.AspNetRoles = new Collection<AspNetRoles>();
            //    foreach (AspNetRoles c in _db.UserRolesEntitys.Where(co => ("user" == co.Name)).ToList())
            //    {
            //        user.AspNetRoles.Add(c);
            //    }
            //    _db.UsersEntitys.Add(user);
            //    _db.SaveChanges();
            //});
            return null;
        }

        public Task UpdateAsync(AppUserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(AppUserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task<AppUserDto> FindByIdAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<AppUserDto> FindByNameAsync(string userName)
        {
            return FindByEmailAsync(userName);
        }

        public Task SetEmailAsync(AppUserDto user, string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetEmailAsync(AppUserDto user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(AppUserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(AppUserDto user, bool confirmed)
        {
            throw new System.NotImplementedException();
        }

        public Task<AppUserDto> FindByEmailAsync(string email)
        {
            Task<User> userIsCheckResult = Task<User>.Factory.StartNew(() => _db.Users.FirstOrDefault(x => x.Email.Equals(email)));
            var result = Mapper.Map<Task<User>,Task<AppUserDto>> (userIsCheckResult);
            return result;
        }

        public Task SetPasswordHashAsync(AppUserDto user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult<Object>(null);
        }

        public Task<string> GetPasswordHashAsync(AppUserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(AppUserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task AddToRoleAsync(AppUserDto user, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveFromRoleAsync(AppUserDto user, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(AppUserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(AppUserDto user, string roleName)
        {
            throw new System.NotImplementedException();
        }
    }
}