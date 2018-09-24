using Autofac;
using static System.Reflection.Assembly;
using Module = Autofac.Module;

namespace Github.Drawer
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(
                    GetAssembly(GetType()))
                .AsImplementedInterfaces();
        }
    }
}