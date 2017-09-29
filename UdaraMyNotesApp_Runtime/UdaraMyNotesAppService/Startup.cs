using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(UdaraMyNotesAppService.Startup))]

namespace UdaraMyNotesAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}