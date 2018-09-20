using System;
using Autofac;
using Github.Drawer.Abstractions;

namespace Github.Drawer
{
    class Program
    {
        private static ContainerBuilder _builder;
        private static IContainer _container;

        public static void Main(string[] args)
        {
            Configure();
        }

        static void Configure()
        {
            _builder = new ContainerBuilder();
            _builder.RegisterModule(new AutofacModule());
            _container = _builder.Build();
        }

        static void Draw()
        {
            var drawer = _container.Resolve<IGithubDrawer>();
            var logger = _container.Resolve<ILogger>();

            try
            {
                drawer.Draw("asdasd");
            }
            catch (Exception e)
            {
                logger.Error("Operations cancelled", e);
            }
        }
    }
}