using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5Homework20161016.Startup))]
namespace MVC5Homework20161016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
