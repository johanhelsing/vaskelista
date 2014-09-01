using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vaskelista.Startup))]
namespace Vaskelista
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
