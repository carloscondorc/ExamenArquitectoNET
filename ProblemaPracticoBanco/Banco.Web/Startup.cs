using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Banco.Web.Startup))]
namespace Banco.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
