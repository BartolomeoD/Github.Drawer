using Autofac;

namespace Github.Drawer
{
    class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes()
                .AsImplementedInterfaces();
        }
    }
}