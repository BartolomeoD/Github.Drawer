using System;
using Autofac;
using Github.Drawer.Abstractions;

namespace Github.Drawer
{
    public class Program
    {
        private static ContainerBuilder _builder;
        private static IContainer _container;

        public static void Main(string[] args)
        {
            var config = new Configuration()
            {
                MaxCommitsCount = 10,
                SchemaFilePath = "example.txt",
                UserEmail = "test",
                UserName = "test",
                FileName = "alone_file.txt",
                DirectoryPath = "test"
            };
            ConfigureContainer();
            Draw(config);
        }

        private static void ConfigureContainer()
        {
            _builder = new ContainerBuilder();
            _builder.RegisterModule(new AutoFacModule());
            _container = _builder.Build();
        }

        static void Draw(Configuration configuration)
        {
            var drawer = _container.Resolve<IGithubDrawer>();
            var logger = _container.Resolve<ILogger>();

            try
            {
                drawer.Draw(configuration);
            }
            catch (Exception e)
            {
                logger.Error("Operations cancelled", e);
            }

            Console.ReadKey();
        }
    }
}