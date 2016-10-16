using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5Homework1.Startup))]
namespace MVC5Homework1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
