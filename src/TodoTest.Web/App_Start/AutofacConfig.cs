using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using TodoTest.DataAccess;

namespace TodoTest.Web
{
    public static class AutofacConfig
    {
        public static void RegisterDependencyInjection(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var dalAssembly = Assembly.GetAssembly(typeof(TodoRepository));
            builder.RegisterAssemblyTypes(dalAssembly)
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}