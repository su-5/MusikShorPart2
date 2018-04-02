using System.Threading.Tasks;
using DAL.Core;
using DAL.Core.ModelDTO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace BLL.Core.Identity
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class CustomUserManager : UserManager<User>
    {
        public CustomUserManager(UserIdentityStore store)
            : base(store)
        {
        }

        public static CustomUserManager Create(IdentityFactoryOptions<CustomUserManager> options, IOwinContext context)
        {
            var manager = new CustomUserManager(new UserIdentityStore(context.Get<MusicDataBaseEntities>()));
            // Настройка логики проверки имен пользователей
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Настройка логики проверки паролей
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,//минимальная длина пароля
                RequireNonLetterOrDigit = true,//если равно true, то пароль должен будет иметь как минимум один символ, который не является алфавитно-цифровым
                RequireDigit = true,//если равно true, то пароль должен будет иметь как минимум одну цифру
                RequireLowercase = true,// если равно true, то пароль должен будет иметь как минимум один символ в нижнем регистре
                RequireUppercase = true,//если равно true, то пароль должен будет иметь как минимум один символ в верхнем регистре
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public async Task<IdentityResult> PasswordValidatorUser(string user)
        {
            Task<IdentityResult> validateAsync = PasswordValidator.ValidateAsync(user);
            return await validateAsync;
        }

        public async Task<bool> ChangeEmail(User user, string email)
        {
            if (await base.FindByEmailAsync(email) != null)
            {
                return false;
            }

            user.Email = email;
            await Store.UpdateAsync(user);
            return true;
        }
    }
}
