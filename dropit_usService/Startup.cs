using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(dropit_usService.Startup))]

namespace dropit_usService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}