using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeHelper.Startup))]
namespace EmployeeHelper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
