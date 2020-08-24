using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppWebC.Startup))]
namespace AppWebC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
