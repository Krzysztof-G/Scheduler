using Autofac;
using System.Reflection;

namespace Scheduler.Helpers.DependencyInjection
{
    public static class Resolver
    {
        public static IContainer Container;

        public static void RegisterAutofacDependencyInjection()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ServiceModule());
            Container = builder.Build();
        }
    }
}
