using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SOLID.WebApi.Startup))]

namespace SOLID.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
