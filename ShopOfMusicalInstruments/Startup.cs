using Microsoft.Owin;
using Owin;
using ShopOfMusicalInstruments.Core;

[assembly: OwinStartup(typeof(Startup))]

namespace ShopOfMusicalInstruments.Core
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
