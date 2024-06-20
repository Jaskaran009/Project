using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Passion_project_Jaskaran_n01664609.Startup))]
namespace Passion_project_Jaskaran_n01664609
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
