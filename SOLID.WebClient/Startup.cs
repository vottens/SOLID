using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SOLID.WebClient.Startup))]

namespace SOLID.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
