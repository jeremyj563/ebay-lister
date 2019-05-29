using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ebay_lister.Startup))]
namespace ebay_lister
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
