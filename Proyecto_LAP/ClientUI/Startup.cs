using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClientUI.Startup))]
namespace ClientUI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
