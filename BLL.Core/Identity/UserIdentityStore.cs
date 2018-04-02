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
    public class UserIdentityStore : IUserStore<User>, IUserEmailStore<User>,
       IUserPasswordStore<User>, IUserRoleStore<User>
    {
        MusicDataBaseEntities _db = new MusicDataBaseEntities();

        public UserIdentityStore(MusicDataBaseEntities context)
        {
           // _db = context;
        }

        public void Dispose()
        {
        }


        public Task CreateAsync(User user)
        {
            return Task.Factory.StartNew(() =>
            {
                User userDb = user;
                userDb.Roles = new Collection<Role>();
                foreach (Role c in _db.Roles.Where(co => ("user" == co.Name)).ToList())
                {
                    userDb.Roles.Add(c);
                }
                _db.Users.Add(userDb);
                _db.SaveChanges();
            });

        }

        public Task UpdateAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId)
        {
            Task<User> userIsResult = Task<User>.Factory.StartNew(() => _db.Users.FirstOrDefault(x => x.Id.Equals(userId)));
            var result = userIsResult;
            return result;
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return FindByEmailAsync(userName);
        }

        public Task SetEmailAsync(User user, string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetEmailAsync(User user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindByEmailAsync(string email)
        {
            Task<User> userIsCheckResult = Task<User>.Factory.StartNew(() => _db.Users.FirstOrDefault(x => x.Email.Equals(email)));
            var result = Mapper.Map<Task<User>,Task<User>> (userIsCheckResult);
            return result;
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult<Object>(null);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task AddToRoleAsync(User user, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            User userDb = user;
            if (userDb == null)
            {
                throw new ArgumentNullException("user");
            }
            foreach (var roles in userDb.Roles.Select(variable => variable.Name))
            {
                if (roles != null)
                {
                    return Task.FromResult<IList<string>>(new[] { roles });
                }
            }
            return Task.FromResult<IList<string>>(null);
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            throw new System.NotImplementedException();
        }
    }
}