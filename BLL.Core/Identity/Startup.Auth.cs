using DAL.Core;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace BLL.Core.Identity
{
    public class StartupAuth
    {
        //   public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }

        // Дополнительные сведения о настройке аутентификации см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Настройка контекста базы данных и диспетчера пользователей для использования одного экземпляра на запрос
           // app.CreatePerOwinContext(MusicDataBaseEntities.Create());
            app.CreatePerOwinContext<CustomUserManager>(CustomUserManager.Create);

            // Настройка контекста базы данных и диспетчера пользователей для использования одного экземпляра на запрос
            // app.CreatePerOwinContext(AppDbInitializer.ApplicationDbContext.Create);


            // Включение использования файла cookie, в котором приложение может хранить информацию для пользователя, выполнившего вход,
            // и использование файла cookie для временного хранения информации о входах пользователя с помощью стороннего поставщика входа
            app.UseCookieAuthentication(new CookieAuthenticationOptions());// эти куки для хранения пользователя
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie); //это с помощью стороннего поставщика входа

            // Настройка приложения для потока обработки на основе OAuth
            //  PublicClientId = "self";
            //   OAuthOptions = new OAuthAuthorizationServerOptions
            //     {
            //        TokenEndpointPath = new PathString("/Token"),
            //       Provider = new ApplicationOAuthProvider(PublicClientId),
            //       AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
            //       AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
            //        AllowInsecureHttp = true
            //    };

            // Включение использования приложением маркера-носителя для аутентификации пользователей
            //    app.UseOAuthBearerTokens(OAuthOptions);

            // Раскомментируйте приведенные далее строки, чтобы включить вход с помощью сторонних поставщиков входа
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}
