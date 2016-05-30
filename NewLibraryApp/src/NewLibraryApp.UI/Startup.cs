using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewLibraryApp.UI.Startup))]
namespace NewLibraryApp.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
