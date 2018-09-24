using Autofac;
using Github.Drawer;

namespace Tests
{
    public class BaseTest
    {
        protected ContainerBuilder Builder;
        protected IContainer Container;

        public BaseTest()
        {
            Builder = new ContainerBuilder();
            Builder.RegisterModule(new AutoFacModule());
            Container = Builder.Build();
        }
    }
}