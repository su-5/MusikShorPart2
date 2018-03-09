using BLL.Core.Identity;
using Microsoft.Owin;
using Owin;
using ShopOfMusicalInstruments.Core;

[assembly: OwinStartup(typeof(Startup))]

namespace ShopOfMusicalInstruments.Core
{
    public class Startup
    {
        private readonly StartupAuth _startupAuth = new StartupAuth();
        public void Configuration(IAppBuilder app)
        {
            _startupAuth.ConfigureAuth(app);
        }
    }
}
