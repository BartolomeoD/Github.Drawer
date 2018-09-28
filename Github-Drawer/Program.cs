using System;
using Autofac;
using Fclp;
using Github.Drawer.Abstractions;

namespace Github.Drawer
{
    public class Program
    {
        private static ContainerBuilder _builder;
        private static IContainer _container;

        public static void Main(string[] args)
        {
            var config = new FluentCommandLineParser<Configuration>();
            config.Setup(arg => arg.MaxCommitsCount)
                .As(CaseType.CaseInsensitive, "max-commit-count", "commit")
                .WithDescription("Maximum commits in one day in last year (Darkest cell in table)")
                .SetDefault(4);

            config.Setup(arg => arg.SchemaFilePath)
                .As(CaseType.CaseInsensitive, "schema")
                .WithDescription("path to schema. Default set to \"example.txt\". See for understanding.")
                .SetDefault("example.txt");

            config.Setup(arg => arg.UserEmail)
                .As(CaseType.CaseInsensitive, "user-email", "e")
                .WithDescription(
                    "github`s account user email. it is safe. it using to signature commits. And github will correctly recognize commits")
                .Required();

            config.Setup(arg => arg.UserName)
                .As(CaseType.CaseInsensitive, "user-name", "n")
                .WithDescription(
                    "github`s account user name. same as email, it is safe. it using to signature commits. And github will correctly recognize commits")
                .Required();

            config.Setup(arg => arg.FileName)
                .As(CaseType.CaseInsensitive, "file-name")
                .WithDescription("Default set to \"alone_file.txt\". File name that contains all commits.")
                .SetDefault("alone_file.txt");

            config.Setup(arg => arg.DirectoryPath)
                .As(CaseType.CaseInsensitive, "directory-path")
                .WithDescription("repository`s directory name, where will be your project. Default set to \"push_me\"")
                .SetDefault("push_me");

            config.SetupHelp("h", "help")
                .Callback(text => Console.WriteLine(text));

            var result = config.Parse(args);
            Console.WriteLine(config.Object.ToString());
            if (result.HasErrors)
            {
                Console.WriteLine("There is error in input data, check -h for information");
                return;
            }
            Console.WriteLine("After creating project you should push it in your github account");
            ConfigureContainer();
            Draw(config.Object);
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
        }
    }
}