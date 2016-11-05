using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Unipam.TCC.Web.Startup))]
namespace Unipam.TCC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
