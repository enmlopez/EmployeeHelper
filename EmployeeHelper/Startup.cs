using Autofac;
using Autofac.Integration.Mvc;
using EmployeeHelper.Contracts;
using EmployeeHelper.Services;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(EmployeeHelper.Startup))]
namespace EmployeeHelper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            builder.RegisterType<OverTimeServices>().As<IOverTimeServices>();
            builder.RegisterType<BufferServices>().As<IBufferServices>();
            builder.RegisterType<BTServices>().As<IBTServices>();
            builder.RegisterType<ShiftServices>().As<IShiftServices>();
            builder.RegisterType<TServices>().As<ITamcTymcServices>();

            //Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            ConfigureAuth(app);
        }
    }
}
