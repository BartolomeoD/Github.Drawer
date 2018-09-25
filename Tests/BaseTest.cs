using Autofac;
using Github.Drawer;
using Xunit.Abstractions;

namespace Tests
{
    public class BaseTest
    {
        protected ITestOutputHelper Output;
        protected ContainerBuilder Builder;
        protected IContainer Container;

        public BaseTest(ITestOutputHelper output)
        {
            Builder = new ContainerBuilder();
            Builder.RegisterModule(new AutoFacModule());
            Container = Builder.Build();
            Output = output;
        }
    }
}