using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PizzaApp.UI.Startup))]
namespace PizzaApp.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
