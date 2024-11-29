using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExciseAPI.Startup))]
namespace ExciseAPI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
